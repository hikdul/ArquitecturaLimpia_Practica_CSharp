using System;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Consultorios
{
    [TestClass]
    public class CasoDeUsoCrearConsultorioTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IRepositoryConsultorios repository;
        //private IValidator<CommandCrearConsultorio> validador;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoCrearConsultorio casoDeUso;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IRepositoryConsultorios>();
            //validador = Substitute.For<IValidator<CommandCrearConsultorio>>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoCrearConsultorio(repository, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_commandoValido_ObtenemoIdConsultorio()
        {
            string name = Guid.NewGuid().ToString().Replace("-", "");
            var command = new CommandCrearConsultorio { Nombre = name };
           // validador.ValidateAsync(command).Returns(new ValidationResult());

            var consultorioCreated = new Consultorio(name);
            repository.Agregar(Arg.Any<Consultorio>()).Returns(consultorioCreated);

            var result = await casoDeUso.Handle(command);

            //await validador.Received(1).ValidateAsync(command);
            await repository.Received(1).Agregar(Arg.Any<Consultorio>());
            await unidadDeTrabajo.Received(1).Persistir();
            Assert.AreNotEqual(Guid.Empty, result);
        }

        /*
        [TestMethod]
        public async Task Handle_cuandoHayError_CallBack()
        {
            var command = new CommandCrearConsultorio { Nombre = "consult A" };
            repository.Agregar(Arg.Any<Consultorio>()).Throws<Exception>();
          //  validador.ValidateAsync(command).Returns(new ValidationResult());
            await Assert.ThrowsExceptionAsync<Exception>(
                async () => await casoDeUso.Handle(command)
            );

            await unidadDeTrabajo.DidNotReceive().Persistir();
            await unidadDeTrabajo.Received(1).Reversar();
        }*/
    }
}
