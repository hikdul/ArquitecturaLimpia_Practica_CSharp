using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Borrar
{
    public class CasoDeUsoBorrarCita : IRequestHandler<ComandoBorrarCita>
    {
        private readonly IRepositoryCita repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoBorrarCita(IRepositoryCita repository, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoBorrarCita command)
        {
            var ent = await repository.ObtenerPorId(command.Id);

            if (ent is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            try
            {
                await repository.borrar(ent);
                await unidadDeTrabajo.Persistir();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
