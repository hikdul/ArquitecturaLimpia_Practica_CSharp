using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerDetallesDentista
{
    public class ConsultaObtenerDetalleDentista : IRequest<DentistaDetalle_out>
    {
        public required Guid Id { get; set; }
    }
}