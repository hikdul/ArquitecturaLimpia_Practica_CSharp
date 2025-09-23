using System.ComponentModel.DataAnnotations;

namespace DientesLimpios.API.DTOs
{
    public class Paciente_in
    {
        [Required]
        [StringLength(250, ErrorMessage = "El nombre no puede tener más de 250 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        [StringLength(254) ]
        public string Email { get; set; }
    }
}