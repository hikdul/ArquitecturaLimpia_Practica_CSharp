
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Dominio.Excepciones;
using System.Net;
using System.Text.Json;

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
                case ExcepcionDeValidacion exv:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(exv.ErroresDeValidacion);
                    break;
                case EXcepcionDeReglaDeNegocio exrn:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(exrn.Message);
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
