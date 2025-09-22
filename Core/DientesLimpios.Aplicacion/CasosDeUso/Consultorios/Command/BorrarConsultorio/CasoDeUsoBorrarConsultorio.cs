using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarConsultorio
{
    public class CasoDeUsoBorrarConsultorio : IRequestHandler<ComandoBorrarConsultorio>
    {
        private readonly IRepositoryConsultorios repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoBorrarConsultorio(
            IRepositoryConsultorios repository,
            IUnidadDeTrabajo unidadDeTrabajo
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoBorrarConsultorio request)
        {
            var consultorio = await repository.ObtenerPorId(request.Id) ?? throw new ExcepcionNoEncontrado();

            try
            {
                await repository.borrar(consultorio);
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
