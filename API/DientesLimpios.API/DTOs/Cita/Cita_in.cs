
namespace DientesLimpios.API.DTOs
{
    public class Cita_in
    {
        public Guid PacienteId { get; set; }
        public Guid DentistaId { get; set; }
        public Guid ConsultorioId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
