using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioCita : Repositorio<Cita>, IRepositoryCita
    {
        public RepositorioCita(DientesLimpiosDBContext context)
            : base(context) { }
    }
}
