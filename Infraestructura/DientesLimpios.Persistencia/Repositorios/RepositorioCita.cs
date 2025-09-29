using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Dominio.Enums;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioCita : Repositorio<Cita>, IRepositoryCita
    {
        private readonly DientesLimpiosDBContext context;

        public RepositorioCita(DientesLimpiosDBContext context)
            : base(context)
        {
            this.context = context;
        }

        public new async Task<Cita> ObtenerPorId(Guid Id)
        {
            return await context
                .Citas.Include(c => c.Paciente)
                .Include(c => c.Dentista)
                .Include(c => c.Consultorio)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<bool> ExisteCitaEnRango(Guid dentistaId, DateTime inicio, DateTime fin)
        {
            return await context
                .Citas.Where(c =>
                    c.DentistaId == dentistaId
                    && c.Estado == EstadoCita.Programada
                    && c.Inicio < x.IntervaloDeTiempo.Fin
                    && c.fin > x.IntervaloDeTiempo.Inicio
                )
                .AnyAsync();
        }
    }
}
