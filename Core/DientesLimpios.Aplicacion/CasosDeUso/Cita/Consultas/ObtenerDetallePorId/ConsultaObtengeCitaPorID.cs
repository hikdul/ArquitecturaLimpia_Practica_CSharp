
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerDetallePorID
{
    public class ConsultaObtengeCitaPorID: IRequest<CItaDetalleDTO>
    {
        public required Guid Id { get; set; }
    }

    
}