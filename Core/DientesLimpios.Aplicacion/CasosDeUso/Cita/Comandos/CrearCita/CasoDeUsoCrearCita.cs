using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Crear
{
    public class CasoDeUsoCrearCita : IRequestHandler<ComandoCrearCita, Guid>
    {
        private readonly IRepositoryCita repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;
        private readonly IServiceNotificaciones serviceNotificaciones;

        public CasoDeUsoCrearCita(
            IRepositoryCita repository,
            IUnidadDeTrabajo unidadDeTrabajo,
            IServiceNotificaciones serviceNotificaciones
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
            this.serviceNotificaciones = serviceNotificaciones;
        }

        public async Task<Guid> Handle(ComandoCrearCita command)
        {
            IntervaloDeTiempo it = new(command.Inicio, command.Fin);
            var Cita = new DientesLimpios.Dominio.Entidades.Cita(
                command.PacienteId,
                command.DentistaId,
                command.ConsultorioId,
                it
            );

            Guid? Id = null;

            try
            {
                var resp = await repository.Agregar(Cita);
                await unidadDeTrabajo.Persistir();
                Id = resp.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await unidadDeTrabajo.Reversar();
                throw;
            }

            var citaDB = await repository.ObtenerPorId(Id.Value);
            var notificacion = citaDB.aDto();
            await serviceNotificaciones.EnviarConfirmacionCita(notificacion);

            return Id.Value;
        }
    }
}
