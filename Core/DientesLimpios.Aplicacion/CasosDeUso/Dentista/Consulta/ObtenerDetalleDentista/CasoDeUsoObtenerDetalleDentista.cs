using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerDetallesDentista
{
    public class CasoDeUsoObtenerDetalleDentista
        : IRequestHandler<ConsultaObtenerDetalleDentista, DentistaDetalle_out>
    {
        private readonly IRepositoryDentista repository;

        public CasoDeUsoObtenerDetalleDentista(IRepositoryDentista repository)
        {
            this.repository = repository;
        }

        public async Task<DentistaDetalle_out> Handle(ConsultaObtenerDetalleDentista request)
        {
            var dentista = await repository.ObtenerPorId(request.Id);
            if (dentista is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            var dto = dentista.aDto();
            return dto;
        }
    }
}
