using System;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Innfraestructura
{
    public static class RegistroServidiosInfraestructura
    {
        public static IServiceCollection AgregarServiciosDeInfraestructura(
            this IServiceCollection services
        )
        {
            services.AddScoped<IServicioNotificaciones, ServicioCorreos>();
            return services;
        }
    }
}
