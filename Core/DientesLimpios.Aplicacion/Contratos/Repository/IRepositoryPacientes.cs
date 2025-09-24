using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Contratos.Repository
{
    public interface IRepositoryPacientes : IRepository<Paciente> 
    {
        Task<IEnumerable<Paciente>> ObtenerFiltrado(FiltroPacienteDTO filtro);
    }
}
