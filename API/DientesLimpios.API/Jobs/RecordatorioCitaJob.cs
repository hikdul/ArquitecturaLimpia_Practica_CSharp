using DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Recordar;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.API.Jobs
{
    public class RecordatorioCitaJob : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;

        private readonly TimeZoneInfo zonaHorarioRepDominicana =
            TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        public RecordatorioCitaJob(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var ahora = TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.UtcNow,
                    zonaHorarioRepDominicana
                );

                if (ahora.Hour == 8)
                {
                    using var scope = scopeFactory.CreateScope();
                    var Mediador = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await Mediador.Send(new ComandoRecordarCita());
                }
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
