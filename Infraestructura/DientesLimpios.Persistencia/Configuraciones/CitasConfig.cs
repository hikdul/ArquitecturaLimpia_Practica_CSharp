using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DientesLimpios.Persistencia.Configuraciones
{
    public class CitasConfig : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ComplexProperty(
                prop => prop.IntervaloDeTiempo,
                accion =>
                {
                    accion.Property(e => e.Inicio).HasColumnName("FechaInicio").IsRequired();
                    accion.Property(e => e.Fin).HasColumnName("FechaFin").IsRequired();
                }
            );
        }
    }
}
