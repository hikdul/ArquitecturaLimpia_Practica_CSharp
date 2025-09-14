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

            servicios.AddScoped<IRepositorioConsultorios, RepositorioConsultorios>();
            servicios.AddScoped<IUnidadDeTrabajo, UnidadDeTrabjoEFCore>();

            return servicios;
        }
    }
}
