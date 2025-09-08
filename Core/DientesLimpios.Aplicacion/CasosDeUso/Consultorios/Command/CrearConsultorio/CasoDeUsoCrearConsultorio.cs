using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;

//using Internal;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio : IRequestHandler<CommandCrearConsultorio, Guid>
    {
        private readonly IRepositoryConsultorios repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;
 //       private readonly IValidator<CommandCrearConsultorio> validator;

        public CasoDeUsoCrearConsultorio(
            IRepositoryConsultorios repository,
            IUnidadDeTrabajo unidadDeTrabajo
  //          IValidator<CommandCrearConsultorio> validator //?: se quita por que las validaciones se trabajaran por el mediador
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
    //        this.validator = validator;
        }

        public async Task<Guid> Handle(CommandCrearConsultorio command)
        {
            //var resValidator = await validator.ValidateAsync(command);
            //if (!resValidator.IsValid)
            //{
             //   throw new ExcepcionDeValidacion(resValidator);
           // }

            var consultorio = new Consultorio(command.Nombre);
            try
            {
                var resp = await repository.Agregar(consultorio);
                await unidadDeTrabajo.Persistir();
                return resp.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
