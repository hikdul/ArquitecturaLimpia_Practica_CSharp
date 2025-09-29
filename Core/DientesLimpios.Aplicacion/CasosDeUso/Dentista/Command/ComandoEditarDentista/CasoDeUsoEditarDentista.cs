using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.EditarDentista
{
    public class CasoDeUsoEditarDentista : IRequestHandler<ComandoEditarDentista>
    {
        private readonly IRepositoryDentista repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEditarDentista(
            IRepositoryDentista repository,
            IUnidadDeTrabajo unidadDeTrabajo
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEditarDentista request)
        {
            var dientologo = await repository.ObtenerPorId(request.Id);
            if (dientologo is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            dientologo.actualizarEmail(new(request.Email));
            dientologo.actualizarNombre(request.Nombre);

            try
            {
                await repository.Actualizar(dientologo);
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
