namespace DientesLimpios.API.Utils
{
    public static class HttpContextExtensions
    {
        public static void InsertarPaginacionEnCabecera(
            this HttpContext httpContext,
            int cantidadDeRegistros
        )
        {
            httpContext.Response.Headers.Append(
                "Cantidad-total-registros",
                cantidadDeRegistros.ToString()
            );
        }
    }
}
