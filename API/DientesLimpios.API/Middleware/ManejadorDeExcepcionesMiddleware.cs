using DientesLimpios.Aplicacion.Excepcion;

namespace DientesLimpios.API.Middleware
{
    public class ManejadorDeExcepcionesMiddleware
    {
        private readonly RequestDelegate next;

        public ManejadorDeExcepcionesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await ManejarExcepcion(context, ex);
            }
        }

        private Task ManejarExcepcion(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var resultado = string.Empty;

            switch (ex)
            {
                case ExcepcionNoEncontrado:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case ExcepcionDeValidacion:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(ExcepcionDeValidacion.ErroresDeValidacion);
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(resultado);
        }
    }
    
    public static class ManejadorDeExcepcionesMiddlewareExtensions
    {
        public static IApplicationBuilder UseManejadorDeExcepcionesMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ManejadorDeExcepcionesMiddleware>();
        }
    }
}
