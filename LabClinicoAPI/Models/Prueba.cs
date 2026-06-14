using System.ComponentModel.DataAnnotations;

namespace LabClinicoAPI.Models
{
    public class Prueba
    {
        [Key]
        public int IdPrueba { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePrueba { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }
    }
}
