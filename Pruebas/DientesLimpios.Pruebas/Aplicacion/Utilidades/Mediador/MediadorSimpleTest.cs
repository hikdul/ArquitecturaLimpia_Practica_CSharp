using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using FluentValidation;
using NSubstitute;

namespace DientesLimpios.Pruebas.Aplicacion.Utilidades.Mediador
{
    [TestClass]
    public class MediadorSimpleTest
    {
        public class RequestFalso : IRequest<string>
        {
            public string Nombre { get; set; }
        }

        public class HandlerFalse : IRequestHandler<RequestFalso, string>
        {
            public Task<string> Handle(RequestFalso request)
            {
                return Task.FromResult("Respuesta Correcta");
            }
        }

        public class ValidadorRequestFalso : AbstractValidator<RequestFalso>
        {
            public ValidadorRequestFalso()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        [TestMethod]
        public async Task Send_llamarMetodoHandler()
        {
            var request = new RequestFalso() { Nombre = "hola mundo" };
            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider
                .GetService(typeof(IRequestHandler<RequestFalso, string>))
                .Returns(casoDeUsoMock);

            var mediador = new MediadorSimple(serviceProvider);

            var resultado = await mediador.Send(request);

            await casoDeUsoMock.Received(1).Handle(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeMediador))]
        public async Task Send_sinHandlerRegistrado_throw()
        {
            var request = new RequestFalso() { Nombre = "hola mundo" };
            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();

            var mediador = new MediadorSimple(serviceProvider);

            var resultado = await mediador.Send(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeValidacion))]
        public async Task Send_comanndoNoValdio_throw()
        {
            var request = new RequestFalso { Nombre = string.Empty };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validador = new ValidadorRequestFalso();

            serviceProvider.GetService(typeof(IValidator<RequestFalso>)).Returns(validador);

            var mediador = new MediadorSimple(serviceProvider);

            await mediador.Send(request);
            //!: al usar el modo solicitado; simplemnete no me entrega la excepcion....
            // await Assert.ThrowsExceptionAsync<ExcepcionDeValidacion>(async () =>
            //{
            //});
        }
    }
}
