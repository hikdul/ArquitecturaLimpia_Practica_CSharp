using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListadoFG;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Contratos.Repository
{
    public interface IRepositoryCita : IRepository<Cita>
    {
        Task<bool> ExisteCitaEnRango(Guid dentistaId, DateTime inicio, DateTime fin);
        //?: con el new reemplaza el metodo del padre (IRepository) para que retorne una Cita y no un objeto generico
        new Task<Cita?> ObtenerPorId(Guid id);
        Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtro);
    }
}
