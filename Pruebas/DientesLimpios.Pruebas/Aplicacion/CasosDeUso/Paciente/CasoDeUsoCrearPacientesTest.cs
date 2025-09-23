using System;
using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.CrearPaciente;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Paciente
{
    [TestClass]
    public class CasoDeUsoCrearPacientesTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IRepositoryPacientes repository;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoCrearPaciente casoDeUso;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IRepositoryPacientes>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoCrearPaciente(repository, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_commandoValido_CreaPAciente_persiste_y_retornaID()
        {
            string name = Guid.NewGuid().ToString().Replace("-", "");
            var command = new ComandoCrearPaciente { Nombre = name, Email = $"{name}@test.com" };
            var pacienteCreated = new Paciente(name, new Email(command.Email));
            var id = pacienteCreated.Id;

            repository.Agregar(Arg.Any<Paciente>()).Returns(pacienteCreated);
            var IdResult = await casoDeUso.Handle(command);

            Assert.AreEqual(id, IdResult);
            await repository.Received(1).Agregar(Arg.Any<Paciente>());
            await unidadDeTrabajo.Received(1).Persistir();
        }
    }
}
