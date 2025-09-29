using System;
using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia
{
    public class DientesLimpiosDBContext : DbContext
    {
        public DientesLimpiosDBContext(DbContextOptions<DientesLimpiosDBContext> options)
            : base(options) { }

        protected DientesLimpiosDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DientesLimpiosDBContext).Assembly);
        }

        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }

    }
}
