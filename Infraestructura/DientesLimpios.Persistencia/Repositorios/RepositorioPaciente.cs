using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioPaciente : Repositorio<Paciente>, IRepositoryPacientes
    {
        private readonly DientesLimpiosDBContext context;

        public RepositorioPaciente(DientesLimpiosDBContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Paciente>> ObtenerFiltrado(FiltroPacienteDTO filtro)
        {
            var querable = context.Pacientes.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nombre))
            {
                querable = querable.Where(p => p.Nombre.Contains(filtro.Nombre));
            }

            if (!string.IsNullOrEmpty(filtro.Email))
            {
                querable = querable.Where(p => p.Email.Contains(filtro.Email));
            }

            return await querable
                .Pacientes.OrderBy(x => x.Nombre)
                .Paginar(filtro.Pagina, filtro.RegistroPorPagina)
                .ToListAsync();
        }
    }
}
