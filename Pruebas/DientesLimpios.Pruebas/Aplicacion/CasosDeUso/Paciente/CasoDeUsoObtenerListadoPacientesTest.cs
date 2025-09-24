using System;
using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Paciente
{
    [TestClass]
    public class CasoDeUsoObtenerListadoPacientesTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IRepositoryPacientes repository;
        private CasoDeUsoObtenerListadoClientes casoDeUso;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IRepositoryPacientes>();
            casoDeUso = new CasoDeUsoObtenerListadoClientes(repository);
        }

        [TestMethod]
        public async Task Handle_retornaPacientesPaginadosCorrectamente()
        {
            var pagina = 1;
            var registrosPorPagina = 2;

            var FiltroPacienteDTO = new FiltroPacienteDTO
            {
                Pagina = pagina,
                RegistroPorPagina = registrosPorPagina,
            };


            var p1 = new DientesLimpios.Dominio.Entidades.Paciente("p1", new Email("p1@p1.ve"));
            var p2 = new DientesLimpios.Dominio.Entidades.Paciente("p2", new Email("p2@p1.ve"));

            IEnumerable<DientesLimpios.Dominio.Entidades.Paciente> pacientes =
                new List<DientesLimpios.Dominio.Entidades.Paciente> { p1, p2 };

            repository
                .ObtenerFiltrado(Arg.Any<FiltroPacienteDTO>())
                .Returns(Task.FromResult(pacientes));

            repository.ObtenerCantidadTotalRegistros().Returns(Task.FromResult(10));

            var request = new ConsultaObtenerListadoClientes
            {
                Pagina = pagina,
                RegistroPorPagina = registrosPorPagina,
            };
            var result = await casoDeUso.Handle(request);

            Assert.AreEqual(10, result.Total);
            Assert.AreEqual(2, result.Elements.Count);
            Assert.AreEqual("p2", result.Elements[1].Nombre);
        }
        
        [TestMethod]
        public async Task  Handle_NoHayPacientes_retornaListaVacia()
        {
            var pagina = 1;
            var registrosPorPagina = 5;

            var FiltroPacienteDTO = new FiltroPacienteDTO
            {
                Pagina = pagina,
                RegistroPorPagina = registrosPorPagina,
            };

            IEnumerable<DientesLimpios.Dominio.Entidades.Paciente> pacientes =
                new List<DientesLimpios.Dominio.Entidades.Paciente>();
            
            repository
                .ObtenerFiltrado(Arg.Any<FiltroPacienteDTO>())
                .Returns(Task.FromResult(pacientes));

            repository.ObtenerCantidadTotalRegistros().Returns(Task.FromResult(0));

            var request = new ConsultaObtenerListadoClientes
            {
                Pagina = pagina,
                RegistroPorPagina = registrosPorPagina
            };

            var result = await casoDeUso.Handle(request);

            Assert.AreEqual(0, result.Total);
            Assert.IsNotNull(result.Elements);
            Assert.AreEqual(0, result.Elements.Count);
        }
    }
}
