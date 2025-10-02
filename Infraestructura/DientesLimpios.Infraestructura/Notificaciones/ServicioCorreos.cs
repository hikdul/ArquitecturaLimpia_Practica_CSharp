using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using Microsoft.Extensions.Configuration;

namespace DientesLimpios.Innfraestructura.Notificaciones
{
    public class ServicioCorreos : IServiceNotificaciones
    {
        private readonly IConfiguration configuration;

        public ServicioCorreos(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task EnviarConfirmacionCita(ConfirmacionCitaDTO cita)
        {
            var asunto = "Confirmacion De Cita - Dientes Limpios";
            var cuerpo =
                $@" Estimado(a) {cita.Paciente},

            Su cita con el profesiona {cita.Dentista} ha sido programada para el {cita.Fecha.ToString("f", new CultureInfo("es-DO"))}.
            
            le Esperamos!

            Equipo de Dientes Limpios
            ";

            await EnviarMail(cita.Paciente_Email, asunto, cuerpo);
        }

        private async Task EnviarMail(string email, string asunto, string cuerpo)
        {
            var nuesrtoEmail = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var port = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PORT");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(nuesrtoEmail, password);

            var message = new MailMessage(nuesrtoEmail, email, asunto, cuerpo);
            await smtpClient.SendMailAsync(message);
        }

        public async Task EnviarRecordatorioCita(RecordatorioCitaDTO cita)
        {
            var asunto = "RECORDATORIO: Confirmacion de cita - Dientes limpios";
            var cuerpo =
                @$"
            Estimado (a) {cita.Paciente}
            
            Le recordamos que tienen cita con el profesional {cita.Dentista} para el {cita.Fecha.ToString("f", new CultureInfo("es-DO"))}
            
            le esperamos!
            
            
            equipo de dientes limpios...
            
            ";

            await EnviarMail(cita.Paciente_Email, asunto, cuerpo);
        }
    }
}
