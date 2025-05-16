using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(1, 100, ErrorMessage = "La edad debe estar entre 1 y 100")]
        public int Edad { get; set; }
        
        [Required(ErrorMessage = "El curso es obligatorio")]
        [StringLength(50, ErrorMessage = "El curso no puede exceder los 50 caracteres")]
        public string Curso { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El promedio es obligatorio")]
        [Range(0, 10, ErrorMessage = "El promedio debe estar entre 0 y 10")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Promedio { get; set; }
        
        // Nota: La relación con Course se maneja a través del campo Curso (string)
    }
}
