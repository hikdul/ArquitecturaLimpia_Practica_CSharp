using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Command.CompletarCita
{
    public class ComandoCompletarCita : IRequest
    {
        public required Guid Id { get; set; }
    }
}
