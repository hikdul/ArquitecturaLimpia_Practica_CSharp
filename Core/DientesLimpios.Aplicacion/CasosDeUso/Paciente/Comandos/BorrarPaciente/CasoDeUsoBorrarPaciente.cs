using System;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.BorrarPaciente
{
    public class CasoDeUsoBorrarPaciente : IRequestHandler<ComandoBorrarPaciente>
    {
        private readonly IRepositorioPaciente repositorio;
        private readonly IUnidadDeTrabajo unitOfWork;

        public CasoDeUsoBorrarPaciente(
            IRepositorioPaciente repositorioPaciente,
            IUnidadDeTrabajo unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
            this.repositorio = repositorioPaciente;
        }

        public async Task Handle(ComandoBorrarPaciente request, CancellationToken cancellationToken)
        {
            var paciente = repositorio.ObtenerPorId(request.Id);

            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            try
            {
                await repositorio.Borrar(paciente);
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
