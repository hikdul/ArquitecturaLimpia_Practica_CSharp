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
            return await context
                .Pacientes.OrderBy(x => x.Nombre)
                .Paginar(filtro.Pagina, filtro.RegistroPorPagina)
                .ToListAsync();
        }
    }
}
