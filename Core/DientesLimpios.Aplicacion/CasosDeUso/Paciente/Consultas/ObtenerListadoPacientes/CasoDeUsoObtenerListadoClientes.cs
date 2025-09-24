using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Common;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    public class CasoDeUsoObtenerListadoClientes
        : IRequestHandler<ConsultaObtenerListadoClientes, PaginadoDTO<PacienteListadoDTO>>
    {
        private readonly IRepositoryPacientes repository;

        public CasoDeUsoObtenerListadoClientes(IRepositoryPacientes repository)
        {
            this.repository = repository;
        }

        public async Task<PaginadoDTO<PacienteListadoDTO>> Handle(
            ConsultaObtenerListadoClientes request
        )
        {
            var pacientes = await repository.ObtenerFiltrado(request);
            var totalPacientes = await repository.ObtenerCantidadTotalRegistros();
            var pacienteDTO = pacientes.Select(p => p.ADto()).ToList();

            PaginadoDTO<PacienteListadoDTO> _out = new()
            {
                Elements = pacienteDTO,
                Total = totalPacientes,
            };

            return _out;
        }
    }
}
