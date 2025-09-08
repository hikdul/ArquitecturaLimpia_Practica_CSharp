using System;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio
{
    public class ConsultaObtenerDetalleConsultorio : IRequest<ConsultarioDetalleDTO>
    {
        public Guid Id { get; set; }
    }
}
