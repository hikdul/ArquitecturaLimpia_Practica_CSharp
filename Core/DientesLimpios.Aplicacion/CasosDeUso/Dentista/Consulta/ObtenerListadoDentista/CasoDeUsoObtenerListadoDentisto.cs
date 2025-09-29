using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerListadoDentista
{
    public class CasoDeUsoObtenerListadoDentisto
        : IRequestHandler<ConsultaObtenerListadoDentistas, List<Dentista_out>>
    {
        private readonly IRepositoryDentista repository;

        public CasoDeUsoObtenerListadoDentisto(IRepositoryDentista repository)
        {
            this.repository = repository;
        }

        public async Task<List<Dentista_out>> Handle(ConsultaObtenerListadoDentistas request)
        {
            var list = await repository.ObtenerTodos();
            var ret = list.Select(p => p.aDto()).ToList();
            return ret;
        }
    }
}
