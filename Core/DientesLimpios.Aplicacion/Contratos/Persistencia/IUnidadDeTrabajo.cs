namespace DientesLimpios.Aplicacion.Contratos.Persistencia
{
    /// <summary>
    /// Este es el centro del patron de Unit to work
    /// </summary>
    public interface IUnidadDeTrabajo
    {
        Task Persistir();

        Task Reversar();
    }
}
