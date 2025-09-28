using System;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Excepcion;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.ActualizarPaciente
{
    public class CasoDeUsoComandoActualizarPaciente : IRequestHandler<ComandoActualizarPaciente>
    {
        private readonly IRepositorioPaciente repositorio;
        private readonly IUnidadDeTrabajo unitOfWork;

        public CasoDeUsoComandoActualizarPaciente(
            IRepositorioPaciente repositorioPaciente,
            IUnidadDeTrabajo unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
            this.repositorio = repositorioPaciente;
        }

        public async Task Handle(
            ComandoActualizarPaciente request,
            CancellationToken cancellationToken
        )
        {
            var paciente = repositorio.ObtenerPorId(request.Id);

            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            paciente.ActualizarNombre(request.Nombre);
            paciente.ActualizarEmail(request.Email);

            try
            {
                await repositorio.Actualizar(paciente);
                await unitOfWork.Persistir();
            }
            catch (System.Exception)
            {
                await unitOfWork.Reversar();
                throw;
            }
        }
    }
}
