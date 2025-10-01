using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListadoFG
{
    public class CasoDeUsoObtenerListaCitasFG
        : IRequestHandler<ConsultaObtenerListadoCitasFG, List<CitaListadoDTO>>
    {
        private readonly IRepositoryCita repository;

        public CasoDeUsoObtenerListaCitasFG(IRepositoryCita repository)
        {
            this.repository = repository;
        }

        public async Task<List<CitaListadoDTO>> Handle(ConsultaObtenerListadoCitasFG request)
        {
            var citas = await repository.ObtenerFiltrado(request);
            var citasDTO = citas.Select(p => p.aDto()).ToList();
            return citasDTO;
        }
    }
}
