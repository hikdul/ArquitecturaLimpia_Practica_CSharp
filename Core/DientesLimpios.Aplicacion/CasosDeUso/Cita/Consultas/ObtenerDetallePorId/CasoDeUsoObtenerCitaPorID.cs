using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerDetallePorID
{
    public class CasoDeUsoObtenerCitaPorID
        : IRequestHandler<ConsultaObtengeCitaPorID, CItaDetalleDTO>
    {
        private readonly IRepositoryCita repository;

        public CasoDeUsoObtenerCitaPorID(IRepositoryCita repository)
        {
            this.repository = repository;
        }

        public async Task<CItaDetalleDTO> Handle(ConsultaObtengeCitaPorID request)
        {
            var cita = await repository.ObtenerPorId(request.Id);
            if (cita is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            var dto = cita.aDto();
            return dto;
        }
    }
}
