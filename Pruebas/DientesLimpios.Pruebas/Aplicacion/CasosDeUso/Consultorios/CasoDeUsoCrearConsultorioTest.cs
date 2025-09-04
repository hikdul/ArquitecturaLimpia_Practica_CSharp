using System;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using FluentValidation;
using FluentValidation.Result;
using NSubstitute;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Consultorios
{
    [TestClass]
    public class CasoDeUsoCrearConsultorioTest
    {
        private IRepositoryConsultorios repository;
        private IValidator<CommandCrearConsultorio> validator;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoCrearConsultorio casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IRepositoryConsultorios>();
            validator = Substitute.For<IValidator<CommandCrearConsultorio>>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoCrearConsultorio(repository, unidadDeTrabajo, validator);
        }

        [TestMethod]
        public async Task Handle_commandoValido_ObtenemoIdConsultorio()
        {
            string name = Guid.NewGuid().ToString().Replace("-","");
            var command = new CommandCrearConsultorio { Nombre = name };
            validador.ValidateAsync(command).Return(new ValidationResult());

            var consultorioCreated = new Consultorio(name);
            repository.Agregar(Arg.any<Consultorio>()).Return(consultorioCreated);

            var result = await casoDeUso.Handle(command);

            await validator.Received(1).ValidateAsync(command);
            await repository.Received(1).Agregar(Arg.Any<Consultorio>());
            await unidadDeTrabajo.Received(1).Persistir();
            Assirt.AreNotEqual(Guid.Empty, result);


        }
    }
}
