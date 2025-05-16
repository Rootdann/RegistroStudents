using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Data;
using StudentRegistrationSystem.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace StudentRegistrationSystem.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Obtener el nombre de usuario actual
            var username = User.Identity.Name;
            
            // Buscar el usuario en la base de datos
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            var viewModel = new SettingsViewModel
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };
            
            return View(viewModel);
        }
        
        // POST: Settings/UpdateProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(SettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            
            // Buscar el usuario en la base de datos
            var user = _context.Users.Find(model.UserId);
            
            if (user == null)
            {
                TempData["ErrorMessage"] = "Usuario no encontrado.";
                return View("Index", model);
            }
            
            // Actualizar el correo electrónico
            user.Email = model.Email;
            
            // Si se proporcionó una contraseña actual, verificar y actualizar la contraseña
            if (!string.IsNullOrEmpty(model.CurrentPassword))
            {
                // Verificar la contraseña actual
                var hashedCurrentPassword = HashPassword(model.CurrentPassword);
                
                if (user.Password != hashedCurrentPassword)
                {
                    TempData["ErrorMessage"] = "La contraseña actual es incorrecta.";
                    return View("Index", model);
                }
                
                // Verificar que se proporcionó una nueva contraseña
                if (string.IsNullOrEmpty(model.NewPassword))
                {
                    TempData["ErrorMessage"] = "Debe proporcionar una nueva contraseña.";
                    return View("Index", model);
                }
                
                // Actualizar la contraseña
                user.Password = HashPassword(model.NewPassword);
                TempData["SuccessMessage"] = "Contraseña actualizada correctamente.";
            }
            
            try
            {
                // Guardar los cambios
                _context.Update(user);
                _context.SaveChanges();
                
                TempData["SuccessMessage"] = "Perfil actualizado correctamente.";
            }
            catch (DbUpdateConcurrencyException)
            {
                TempData["ErrorMessage"] = "Error al actualizar el perfil. Inténtalo de nuevo.";
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
