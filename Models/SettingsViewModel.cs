using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class SettingsViewModel
    {
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        
        [Display(Name = "Contraseña Actual")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        
        [Display(Name = "Nueva Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string NewPassword { get; set; }
        
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
        
        public bool IsAdmin { get; set; }
        
        public string Theme { get; set; } = "light";
        
        public string PrimaryColor { get; set; } = "blue";
    }
}
