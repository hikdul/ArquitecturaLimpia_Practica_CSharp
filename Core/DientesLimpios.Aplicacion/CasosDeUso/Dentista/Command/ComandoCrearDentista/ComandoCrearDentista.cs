using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearDentista
{
    public class ComandoCrearDentista : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
