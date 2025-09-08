using System;
using System.Threading;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Excepcion;
using FluentValidation;
using FluentValidation.Results;

namespace DientesLimpios.Aplicacion.Utilidades.Mediador
{
    //TODO: aunque se llame simple siento que el trabajo es bastante complejo; el caso es buscar el tipo de mediador para entender cual es la dificultad o cuando deja de ser simple.
    public class MediadorSimple : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public MediadorSimple(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            //~: trabajamos con las validaciones, para tenerlas aca y asi si existen que simplemente se ejecuten en este llamado.

            var tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());
            var validador = serviceProvider.GetService(tipoValidador);

            if (validador is not null)
            {
                var metodoValidar = tipoValidador.GetMethod("ValidateAsync");
                var tareaValidar = (Task)
                    metodoValidar!.Invoke(
                        validador,
                        new object[] { request, CancellationToken.None }
                    )!;

                await tareaValidar.ConfigureAwait(false); //?: esto en .NET no es viable, pero para otros modelos de desarrolla si ya que ironicamente con esto se indica que no use el hilo principal para esperar

                var resultado = tareaValidar.GetType().GetProperty("Result");
                var validationResult = (ValidationResult)resultado!.GetValue(tareaValidar)!;
                if (!validationResult.IsValid)
                {
                    throw new ExcepcionDeValidacion(validationResult);
                }
            }

            //?: aca se esta usando Reflexion
            var tipoCasoDeUso = typeof(IRequestHandler<,>).MakeGenericType(
                request.GetType(),
                typeof(TResponse)
            );

            var casoDeUso = serviceProvider.GetService(tipoCasoDeUso);

            if (casoDeUso is null)
            {
                throw new ExcepcionDeMediador(
                    $"No se encontro un handler para {request.GetType().Name}"
                );
            }

            var metodo = tipoCasoDeUso.GetMethod("Handle")!;
            return await (Task<TResponse>)metodo.Invoke(casoDeUso, new object[] { request })!;
        }
    }
}
