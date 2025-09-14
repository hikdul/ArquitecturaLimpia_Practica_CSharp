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

        public DbSet<Consultorio> Consultorios { get; set; }
    }
}
