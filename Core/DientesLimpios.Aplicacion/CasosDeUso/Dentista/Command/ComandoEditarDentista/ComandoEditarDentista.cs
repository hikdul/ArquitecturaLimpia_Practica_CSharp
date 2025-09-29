using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Command.EditarDentista
{
    public class ComandoEditarDentista : IRequest
    {
        public required Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
