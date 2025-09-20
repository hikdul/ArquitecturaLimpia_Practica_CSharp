using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Aplicacion.Contratos.Repository;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Consultorios
{
    [TestClass]
    public class CasoDeUsoObtenerDetalleConsultorioTest
    {
        private IRepositoryConsultorios repository;
        private CasoDeUsoObtenerDetalleConsultorio casoDeUso;

        [TestInitialize]
        public void Setud()
        {
            repository = Substitute.For<IRepositoryConsultorios>();
            casoDeUso = new CasoDeUsoObtenerDetalleConsultorio(repository);
        }

        [TestMethod]
        public async Task Handle_cosultorioExiste_RetornaDTO()
        {
            //~: Preparacion
            string nombreConsultorio = "Consultorio A";
            var consultorio = new Consultorio(nombreConsultorio);
            var id = consultorio.Id;
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };

            repository.ObtenerPorId(id).Returns(consultorio);

            //~: Prueba
            var result = await casoDeUso.Handle(consulta);

            //~: Verificacion
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(nombreConsultorio, result.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_consultorioNoExiste_lanzaExcepccionNoEncontrado()
        {
            var id = Guid.NewGuid();
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };

            repository.ObtenerPorId(id).ReturnsNull();

            await casoDeUso.Handle(consulta);
        }
    }
}
