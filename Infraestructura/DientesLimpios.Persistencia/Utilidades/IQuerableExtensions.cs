namespace DientesLimpios.Persistencia.Utilidades
{
    public static class IQuerableExtensions
    {
        public static IQueryable<T> Paginar<T>(
            this IQueryable<T> querable,
            int pagina,
            int RegistroPorPagina
        )
        {
            return querable.Skip((pagina - 1) * RegistroPorPagina).Take(RegistroPorPagina);
        }
    }
}
