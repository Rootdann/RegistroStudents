using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Data;
using StudentRegistrationSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Statistics
        public IActionResult Index()
        {
            try
            {
                // Obtener todos los estudiantes sin usar EF Core (para evitar problemas con CourseId)
                var students = _context.Students
                    .FromSqlRaw("SELECT Id, Nombre, Edad, Curso, Promedio FROM Students")
                    .ToList();
                
                // Obtener todos los cursos
                var courses = _context.Courses.ToList();
                
                // Calcular el promedio general
                decimal generalAverage = 0;
                if (students.Any())
                {
                    generalAverage = students.Average(s => s.Promedio);
                }
                
                // Calcular promedios por curso
                var averagesByCourse = new Dictionary<string, decimal>();
                foreach (var course in courses)
                {
                    var courseStudents = students.Where(s => s.Curso == course.Name).ToList();
                    if (courseStudents.Any())
                    {
                        averagesByCourse[course.Name] = courseStudents.Average(s => s.Promedio);
                    }
                    else
                    {
                        averagesByCourse[course.Name] = 0;
                    }
                }
                
                // Obtener el estudiante con mejor promedio
                var bestStudent = students.OrderByDescending(s => s.Promedio).FirstOrDefault();
                
                // Pasar los datos a la vista
                ViewBag.GeneralAverage = generalAverage;
                ViewBag.AveragesByCourse = averagesByCourse;
                ViewBag.BestStudent = bestStudent;
                ViewBag.StudentCount = students.Count;
                ViewBag.CourseCount = courses.Count;
                
                return View(students);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<Student>());
            }
        }
    }
}
