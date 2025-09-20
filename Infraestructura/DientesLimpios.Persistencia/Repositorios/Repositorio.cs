using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Contratos.Repository;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepository<T>
        where T : class
    {
        private readonly DientesLimpiosDBContext context;

        public Repositorio(DientesLimpiosDBContext _context)
        {
            this.context = _context;
        }

        public async Task<T> ObtenerPorId(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task<T> Agregar(T entidad)
        {
            context.Add(entidad);
            return Task.FromResult(entidad);
        }

        public Task borrar(T entidad)
        {
            context.Remove(entidad);
            return Task.CompletedTask;
        }

        public Task Actualizar(T entidad)
        {
            context.Update(entidad);
            return Task.CompletedTask;
        }
    }
}
