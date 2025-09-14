

using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioConsultorios: Repositorio<Consultorio>, IRepositoryConsultorios
    {
        public RepositorioConsultorios(DientesLimpiosDBContext context): base(context)
        {
            
        }
    }
}