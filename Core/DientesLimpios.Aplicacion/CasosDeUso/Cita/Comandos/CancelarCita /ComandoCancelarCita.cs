using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Command.CancelarCita
{
    public class ComandoCancelarCita : IRequest
    {
        public required Guid Id { get; set; }
    }
}
