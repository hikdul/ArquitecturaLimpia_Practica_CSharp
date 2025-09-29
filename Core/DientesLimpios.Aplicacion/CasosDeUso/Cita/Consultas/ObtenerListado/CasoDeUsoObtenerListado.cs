using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListado
{
    public class CasoDeUsoObtenerListado : IRequestHandler<ConsultaObtenerListado, List<Cita_out>>
    {
        private readonly IRepositoryCita repository;

        public CasoDeUsoObtenerListado(IRepositoryCita repository)
        {
            this.repository = repository;
        }

        public async Task<List<Cita_out>> Handle(ConsultaObtenerListado request)
        {
            var ents = await repository.ObtenerTodos();
            var dtos = ents.Select(p => p.aDto()).ToList();
            return dtos;
        }
    }
}
