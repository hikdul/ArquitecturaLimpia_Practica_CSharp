using DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListadoFG;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

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
            var cita = await context
                .Citas.Include(c => c.Paciente)
                .Include(c => c.Dentista)
                .Include(c => c.Consultorio)
                .FirstOrDefaultAsync(c => c.Id == Id);

            return cita;
        }

        public async Task<bool> ExisteCitaEnRango(Guid dentistaId, DateTime inicio, DateTime fin)
        {
            return await context
                .Citas.Where(c =>
                    c.DentistaId == dentistaId
                    && c.Estado == Dominio.Enums.EstadoCita.Programada
                    && c.IntervaloDeTiempo.Inicio < fin
                    && c.IntervaloDeTiempo.Fin > inicio
                )
                .AnyAsync();
        }

        public async Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtro)
        {
            var queryable = context
                .Citas.Include(c => c.Paciente)
                .Include(c => c.Dentista)
                .Include(c => c.Consultorio)
                .AsQueryable();

            if (filtro.ConsultorioId is not null)
            {
                queryable = queryable.Where(x => x.ConsultorioId == filtro.ConsultorioId);
            }

            if (filtro.DentistaId is not null)
            {
                queryable = queryable.Where(x => x.DentistaId == filtro.DentistaId);
            }

            if (filtro.ConsultorioId is not null)
            {
                queryable = queryable.Where(x => x.PacienteId == filtro.PacienteId);
            }

            if (filtro.EstadoCita is not null)
            {
                queryable = queryable.Where(x => x.Estado == filtro.EstadoCita);
            }

            var Ents = await queryable
                .Where(y =>
                    y.IntervaloDeTiempo.Inicio >= filtro.Inicio
                    && y.IntervaloDeTiempo.Fin <= filtro.Fin
                )
                .OrderBy(p => p.IntervaloDeTiempo.Inicio)
                .ToListAsync();

            return Ents;
        }
    }
}
