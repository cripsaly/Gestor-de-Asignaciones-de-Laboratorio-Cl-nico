using System.ComponentModel.DataAnnotations;

namespace LabClinicoAPI.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }
    }
}