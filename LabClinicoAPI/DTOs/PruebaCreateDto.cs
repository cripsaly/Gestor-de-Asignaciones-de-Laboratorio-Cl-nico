using System.ComponentModel.DataAnnotations;

namespace LabClinicoAPI.DTOs
{
    public class PruebaCreateDto
    {
        [Required(ErrorMessage = "El nombre de la prueba es obligatorio")]
        [StringLength(100)]
        public string NombrePrueba { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }
    }
}
