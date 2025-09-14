using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Contratos.Persistencia;

namespace DientesLimpios.Persistencia.UnidadesDeTrabajo
{
    public class UnidadDeTrabjoEFCore : IUnidadDeTrabajo
    {
        private readonly DientesLimpiosDBContext context;

        public UnidadDeTrabjoEFCore(DientesLimpiosDBContext _context)
        {
            this.context = _context;
        }

        public async Task Persistir()
        {
            await context.SaveChangesAsync();
        }

        public Task Reversar()
        {
            // No es necesario implementar este metodo en EF Core
            // Pero en otros casos si puede que se tenga que hacer un rollBack o algo similar.
            return Task.CompletedTask;
        }
    }
}
