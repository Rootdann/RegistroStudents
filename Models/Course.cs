using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StudentRegistrationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre del curso es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string Description { get; set; } = string.Empty;
        
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10")]
        public int Credits { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Nota: La relación con estudiantes se maneja a través del campo Curso en la clase Student
    }
}
