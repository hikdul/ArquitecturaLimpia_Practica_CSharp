using System;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Consultorios
{
    [TestClass]
    public class CasoDeUsoActualizarConsultorioTest
    {
        private IRepositoryConsultorios repository;

        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoActualizarConsultorio casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IRepositoryConsultorios>();
            //validador = Substitute.For<IValidator<CommandCrearConsultorio>>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoActualizarConsultorio(repository, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_CuandoConsultorioExiste_acualizaNombreYPersiste()
        {
            string nombre = Guid.NewGuid().ToString();
            var consultorio = new Consultorio(nombre);
            var id = consultorio.Id;
            var command = new ComandoActualizarConsultorio { Id = id, Nombre = $"{nombre} update" };

            repository.ObtenerPorId(id).Returns(consultorio);

            await casoDeUso.Handle(command);
            await repository.Received(1).Actualizar(consultorio);
            await unidadDeTrabajo.Received(1).Persistir();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_CuandoConsultorioNoExiste_throw()
        {
            var command = new ComandoActualizarConsultorio
            {
                Id = Guid.NewGuid(),
                Nombre = "cualquier cosa",
            };

            repository.ObtenerPorId(command.Id).ReturnsNull();
            await casoDeUso.Handle(command);
        }

        [TestMethod]
        //[ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_CuandoOcurreExceccionAlActualizar_llamaReversarYLanzaExceccion()
        {
            string nombre = Guid.NewGuid().ToString();
            var consultorio = new Consultorio(nombre);
            var id = consultorio.Id;
            var command = new ComandoActualizarConsultorio
            {
                Id = id,
                Nombre = Guid.NewGuid().ToString(),
            };

            repository.ObtenerPorId(id).Returns(consultorio);
            repository.Actualizar(consultorio).Throws(new InvalidOperationException("no importa"));

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                casoDeUso.Handle(command)
            );

            await unidadDeTrabajo.Received(1).Reversar();
        }
    }
}
