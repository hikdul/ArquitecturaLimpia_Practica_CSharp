using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarDentista
{
    public class CasoDeUsoBorrarDentista : IRequestHandler<ComandoBorrarDentista>
    {
        private readonly IRepositoryDentista repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoBorrarDentista(
            IRepositoryDentista repository,
            IUnidadDeTrabajo unidadDeTrabajo
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoBorrarDentista request)
        {
            var ent = await repository.ObtenerPorId(request.Id);
            if (ent is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            try
            {
                await repository.borrar(ent);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
