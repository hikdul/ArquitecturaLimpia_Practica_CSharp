namespace DientesLimpios.Aplicacion.Utilidades.Common
{
    public class PaginadoDTO<T>
    {
        public List<T> Elements { get; set; } = [];
        public int Total { get; set; }
    }
}
