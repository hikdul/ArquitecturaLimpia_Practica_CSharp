using System;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio;
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

            // esto es para registrar ltodo los IrequestHandler con sus scopeds y demas
            services.Scan(scan =>
                scan.FromAssembliesOf(typeof(IMediator))
                    .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                    .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );

            //note: se comenta la forma de registra servicios  de manera manual ya que se va a usar una dependencia para no tener que hacerlo ya que ironicamente tendre que crear muchisimas dependencias en esta capa del sistema.
            /*

            services.AddScoped<
                IRequestHandler<CommandCrearConsultorio, Guid>,
                CasoDeUsoCrearConsultorio
            >();

            services.AddScoped<
                IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultarioDetalleDTO>,
                CasoDeUsoObtenerDetalleConsultorio
            >();

            services.AddScoped<
                IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>,
                CasoDeUsoObtenerListadoConsultorios
            >();

            services.AddScoped<
                IRequestHandler<ComandoActualizarConsultorio>,
                CasoDeUsoActualizarConsultorio
            >();

            services.AddScoped<
                IRequestHandler<ComandoBorrarConsultorio>,
                CasoDeUsoBorrarConsultorio
            >();
            */

            return services;
        }
    }
}
