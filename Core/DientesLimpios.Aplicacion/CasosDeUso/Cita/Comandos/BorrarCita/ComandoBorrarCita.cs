
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Borrar
{
    public class ComandoBorrarCita: IRequest
    {
        public Guid Id { get; set; }
    }
}