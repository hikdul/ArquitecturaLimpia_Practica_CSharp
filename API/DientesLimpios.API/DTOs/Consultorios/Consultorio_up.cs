using System.ComponentModel.DataAnnotations;

namespace DientesLimpios.API.DTOs
{
    public class Consultorio_up
    {
        [Required]
        [StringLength(150)]
        public required string Nombre { get; set; }
    }
}
