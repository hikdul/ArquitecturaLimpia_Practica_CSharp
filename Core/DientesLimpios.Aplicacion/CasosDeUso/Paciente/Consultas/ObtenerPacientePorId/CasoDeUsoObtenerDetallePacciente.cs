using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas.ObtenerPorId;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    public class CasoDeUsoObtenerDetallePacciente
        : IRequestHandler<ConsultaObtenerDetallePaciente, PacienteDetalleDTO>
    {
        private readonly IRepositoryPacientes repository;

        public CasoDeUsoObtenerDetallePacciente(IRepositoryPacientes repository)
        {
            this.repository = repository;
        }

        public async Task<PacienteDetalleDTO> Handle(ConsultaObtenerDetallePaciente request)
        {
            var paciente = await repository.ObtenerPorId(request.Id);
            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            var dto = paciente.ADto();
            return dto;
        }
    }
}
