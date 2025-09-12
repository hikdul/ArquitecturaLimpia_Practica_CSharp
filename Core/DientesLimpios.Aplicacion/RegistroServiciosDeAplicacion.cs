using System;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio;
//using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Aplicacion
{
    public static class RegistroServiciosDeAplicacion
    {
        public static IServiceCollection AgregarServiciosDeApliacion(
            this IServiceCollection services
        )
        {
            services.AddTransient<IMediator, MediadorSimple>();

            services.AddScoped<
                IRequestHandler<CommandCrearConsultorio, Guid>,
                CasoDeUsoCrearConsultorio
            >();

            services.AddScoped<
                IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultarioDetalleDTO>,
                CasoDeUsoObtenerDetalleConsultorio
            >();

            return services;
        }
    }
}
