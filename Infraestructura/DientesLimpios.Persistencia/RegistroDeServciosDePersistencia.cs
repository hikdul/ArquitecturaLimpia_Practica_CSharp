using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Persistencia.Repositorios;
using DientesLimpios.Persistencia.UnidadesDeTrabajo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Persistencia
{
    public static class RegistroDeServciosDePersistencia
    {
        public static IServiceCollection AgregarServiciosDePersistencia(
            this IServiceCollection servicios
        )
        {
            servicios.AddDbContext<DientesLimpiosDBContext>(options =>
                options.UseSqlServer("name=DientesLimpiosDBConnectionString")
            );

            servicios.AddScoped<IUnidadDeTrabajo, UnidadDeTrabjoEFCore>();
            servicios.AddScoped<IRepositoryConsultorios, RepositorioConsultorios>();
            servicios.AddScoped<IRepositoryPacientes, RepositorioPaciente>();
            servicios.AddScoped<IRepositoryDentista, RepositorioDentista>();

            return servicios;
        }
    }
}
