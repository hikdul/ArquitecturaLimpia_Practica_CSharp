using System;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarConsultorio;
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
    public class CasoDeUsoBorrarConsultorioTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IRepositoryConsultorios repository;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoBorrarConsultorio casoDeUso;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IRepositoryConsultorios>();
            //validador = Substitute.For<IValidator<CommandCrearConsultorio>>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoBorrarConsultorio(repository, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Hanle_cuandoConsultorioExiiste_borraConsultorio()
        {
            var id = Guid.NewGuid();
            var nombre = Guid.NewGuid().ToString();
            var command = new ComandoBorrarConsultorio { Id = id };
            var consultorio = new Consultorio(nombre);

            repository.ObtenerPorId(id).Returns(consultorio);

            await casoDeUso.Handle(command);

            await repository.Received(1).borrar(consultorio);
            await unidadDeTrabajo.Received(1).Persistir();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Hanle_cuandoConsultorioNoExiiste_Throw()
        {
            var comando = new ComandoBorrarConsultorio { Id = Guid.NewGuid() };
            repository.ObtenerPorId(comando.Id).ReturnsNull();

            await casoDeUso.Handle(comando);
        }

        [TestMethod]
        public async Task Hanle_cuandoOcurreExcepcion_llamaAReversarYLanzaExcepccion()
        {
            var id = Guid.NewGuid();
            var nombre = Guid.NewGuid().ToString();
            var command = new ComandoBorrarConsultorio { Id = id };
            var consultorio = new Consultorio(nombre);

            repository.ObtenerPorId(id).Returns(consultorio);

            repository.borrar(consultorio).Throws(new InvalidOperationException("no importa"));
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => casoDeUso.Handle(command));
            await unidadDeTrabajo.Received(1).Reversar();
        }
    }
}
