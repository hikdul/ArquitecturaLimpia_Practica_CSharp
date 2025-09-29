
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioDentista : Repositorio<Dentista>, IRepositoryDentista
    {
        private readonly DientesLimpiosDBContext context;

        public RepositorioDentista(DientesLimpiosDBContext context)
            : base(context)
        {
            this.context = context;
        }

        /*public async Task<IEnumerable<Paciente>> ObtenerFiltrado(FiltroPacienteDTO filtro)
        {
            var querable = context.Pacientes.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nombre))
            {
                querable = querable.Where(p => p.Nombre.Contains(filtro.Nombre));
            }

            if (!string.IsNullOrEmpty(filtro.Email))
            {
                querable = querable.Where(p => p.Email.Valor.Contains(filtro.Email));
            }

            return await querable
                .OrderBy(x => x.Nombre)
                .Paginar(filtro.Pagina, filtro.RegistroPorPagina)
                .ToListAsync();
        }*/
    }
}