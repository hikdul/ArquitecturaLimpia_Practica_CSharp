using System;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.BorrarPaciente
{
    public class CasoDeUsoBorrarPaciente : IRequestHandler<ComandoBorrarPaciente>
    {
        private readonly IRepositoryPacientes repositorio;
        private readonly IUnidadDeTrabajo unitOfWork;

        public CasoDeUsoBorrarPaciente(
            IRepositoryPacientes repositorioPaciente,
            IUnidadDeTrabajo unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
            this.repositorio = repositorioPaciente;
        }

        public async Task Handle(ComandoBorrarPaciente request)
        {
            var paciente = await repositorio.ObtenerPorId(request.Id);

            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            try
            {
                await repositorio.borrar(paciente);
                await unitOfWork.Persistir();
            }
            catch (Exception)
            {
                await unitOfWork.Reversar();
                throw;
            }
        }
    }
}
