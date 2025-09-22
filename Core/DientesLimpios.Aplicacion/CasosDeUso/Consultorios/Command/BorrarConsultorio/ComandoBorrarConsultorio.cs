using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarConsultorio
{
    public class ComandoBorrarConsultorio : IRequest
    {
        public Guid Id { get; set; }
    }
}
