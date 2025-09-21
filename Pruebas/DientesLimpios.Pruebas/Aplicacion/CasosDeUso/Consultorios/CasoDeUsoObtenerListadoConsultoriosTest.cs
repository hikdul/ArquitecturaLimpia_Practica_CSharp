using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
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
    public class CasoDeUsoObtenerListadoConsultoriosTest
    {
        private IRepositoryConsultorios repository;
        private CasoDeUsoObtenerListadoConsultorios casoDeUso;

        [TestInitialize]
        public void Setud()
        {
            repository = Substitute.For<IRepositoryConsultorios>();
            casoDeUso = new CasoDeUsoObtenerListadoConsultorios(repository);
        }

        [TestMethod]
        public async Task Handle_consultoriosExisten_RetornaDTOs()
        {
            //~: Preparacion


            string nombreConsultorio1 = Guid.NewGuid().ToString().Replace("-", "");
            string nombreConsultorio2 = Guid.NewGuid().ToString().Replace("-", "");
            List<Consultorio> lista = new List<Consultorio>
            {
                new Consultorio(nombreConsultorio1),
                new Consultorio(nombreConsultorio2)
            };

            //var consulta = new ConsultaObtenerListadoConsultorios { };

            repository.ObtenerTodos().Returns(lista);

            var esperado = lista
                .Select(c => new ConsultorioListadoDTO { Id = c.Id, Nombre = c.Nombre })
                .ToList();

            //~: Prueba
            var result = await casoDeUso.Handle(new ConsultaObtenerListadoConsultorios());

            //~: Verificacion
            Assert.AreEqual(esperado.Count, result.Count);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(esperado[i].Id, result[i].Id);
                Assert.AreEqual(esperado[i].Nombre, result[i].Nombre);
            }
        }

        [TestMethod]
        public async Task Handle_consultoriosNoExisten_RetornaListaVacia()
        {
            //~: Preparacion

            List<Consultorio> lista = new List<Consultorio> { };

            repository.ObtenerTodos().Returns(lista);

            var esperado = lista
                .Select(c => new ConsultorioListadoDTO { Id = c.Id, Nombre = c.Nombre })
                .ToList();

            //~: Prueba
            var result = await casoDeUso.Handle(new ConsultaObtenerListadoConsultorios());

            //~: Verificacion
            Assert.IsNotNull(result);
            Assert.AreEqual(esperado.Count, result.Count);
        }
    }
}
