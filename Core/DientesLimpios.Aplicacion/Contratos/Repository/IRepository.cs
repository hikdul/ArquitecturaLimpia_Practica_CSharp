using System.Collections;

namespace DientesLimpios.Aplicacion.Contratos.Repository
{
    //TODO: una ves se entiendo, generar un obtener por grupos para poder paginar y disminuir la carga
    //TODO: tambien si es posible un obtener por elemonto buscado para dismunuir mas la carga y hacerlo mediante un elemento de busqueda.
    public class IRepository<T>
        where T : class
    {
        Task<T> ObtenerPorId(Guid id);

        Task<IEnumerable<T>> ObtenerTodos();

        Task<T> Agregar(T entidad);

        Task borrar(T entidad);
    }
}
