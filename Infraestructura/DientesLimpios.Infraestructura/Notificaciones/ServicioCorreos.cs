using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;

namespace DientesLimpios.Innfraestructura.Notificaciones
{
    public class ServicioCorreos : IServicioNotificaciones
    {
        public Task EnviarConfirmacionCita(ConfirmacionCitaDTO cita)
        {
            throw new NotImplementedException();
        }
    }
}
