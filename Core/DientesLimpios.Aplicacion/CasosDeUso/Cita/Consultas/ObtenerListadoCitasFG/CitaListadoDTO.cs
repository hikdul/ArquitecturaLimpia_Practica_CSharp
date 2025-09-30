
namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListadoFG
{
    public class CitaListadoDTO
    {
        public required Guid Id { get; set; }
        public required string Paciente { get; set; }
        public required string Dentista { get; set; }
        public required string Consultorio { get; set; }
        public required DateTime Inicio { get; set; }
        public required DateTime Fin { get; set; }
        public required string EstadoCita { get; set; }
        
    }
}