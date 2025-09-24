using DientesLimpios.Aplicacion.Utilidades.Common;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    //public class ConsultaObtenerListadoClientes : IRequest<List<PacienteListadoDTO>>
    public class ConsultaObtenerListadoClientes
        : FiltroPacienteDTO,
            IRequest<PaginadoDTO<PacienteListadoDTO>> { }
}
