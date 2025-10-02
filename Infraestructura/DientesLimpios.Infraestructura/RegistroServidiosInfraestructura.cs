
using Microsoft.Extensions.DependencyInjection;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Innfraestructura.Notificaciones;

namespace DientesLimpios.Innfraestructura
{
    public static class RegistroServidiosInfraestructura
    {
        public static IServiceCollection AgregarServiciosDeInfraestructura(
            this IServiceCollection services
        )
        {
            services.AddScoped<IServiceNotificaciones, ServicioCorreos>();
            return services;
        }
    }
}
