
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios
{
    public class ComandoActualizarConsultorio : IRequest
    {
        public required Guid Id { get; set; }
        public required string Nombre { get; set; }
    }
}