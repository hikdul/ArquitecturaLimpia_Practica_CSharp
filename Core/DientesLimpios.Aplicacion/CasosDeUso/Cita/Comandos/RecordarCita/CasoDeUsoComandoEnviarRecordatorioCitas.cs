using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Enums;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Recordar
{
    public class CasoDeUsoComandoEnviarRecordatorioCitas : IRequestHandler<ComandoRecordarCita>
    {
        private readonly IRepositoryCita repository;
        private readonly IServiceNotificaciones notify;

        public CasoDeUsoComandoEnviarRecordatorioCitas(
            IRepositoryCita repository,
            IServiceNotificaciones notify
        )
        {
            this.repository = repository;
            this.notify = notify;
        }

        public async Task Handle(ComandoRecordarCita request)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            var fechaInicio = tomorrow;
            var fechaFin = tomorrow.AddDays(1);
            var filtro = new FiltroCitasDTO
            {
                Inicio = fechaInicio,
                Fin = fechaFin,
                EstadoCita = EstadoCita.Programada,
            };

            var citas = await repository.ObtenerFiltrado(filtro);
            foreach (var cita in citas)
            {
                var dto = cita.aDto();
                await notify.EnviarRecordatorioCita(dto);
            }
        }
    }
}
