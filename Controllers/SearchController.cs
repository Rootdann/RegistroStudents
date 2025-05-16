using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Data;
using StudentRegistrationSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Search
        public IActionResult Index(string searchTerm = "")
        {
            ViewBag.SearchTerm = searchTerm;
            
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(new SearchViewModel());
            }
            
            var searchTermLower = searchTerm.ToLower();
            
            // Buscar estudiantes
            var students = _context.Students
                .Where(s => s.Nombre.ToLower().Contains(searchTermLower) || 
                            s.Curso.ToLower().Contains(searchTermLower))
                .ToList();
            
            // Buscar cursos
            var courses = _context.Courses
                .Where(c => c.Name.ToLower().Contains(searchTermLower) || 
                            c.Description.ToLower().Contains(searchTermLower))
                .ToList();
            
            var viewModel = new SearchViewModel
            {
                SearchTerm = searchTerm,
                Students = students,
                Courses = courses
            };
            
            return View(viewModel);
        }
    }
    
    public class SearchViewModel
    {
        public string SearchTerm { get; set; } = string.Empty;
        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
        public IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();
    }
}
