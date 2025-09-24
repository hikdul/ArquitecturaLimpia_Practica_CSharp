using System;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    public class ConsultaObtenerDetallePaciente : IRequest<PacienteDetalleDTO>
    {
        public required Guid Id { get; set; }
    }
}