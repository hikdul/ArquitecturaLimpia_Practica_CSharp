using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DientesLimpios.Persistencia.Configuraciones
{
    public class DentistaConfig : IEntityTypeConfiguration<Dentista>
    {
        public void Configure(EntityTypeBuilder<Dentista> builder)
        {
            //builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(250);
            builder.ComplexProperty(
                prop => prop.Email,
                accion =>
                {
                    accion.Property(e => e.Valor).HasColumnName("Email").HasMaxLength(254);
                }
            );
        }
    }
}
