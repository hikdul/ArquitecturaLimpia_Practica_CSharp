using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioPaciente : Repositorio<Paciente>, IRepositoryPacientes
    {
        public RepositorioPaciente(DientesLimpiosDBContext context)
            : base(context) { }
    }
}
