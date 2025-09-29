using System;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.ActualizarPaciente
{
    public class CasoDeUsoComandoActualizarPaciente : IRequestHandler<ComandoActualizarPaciente>
    {
        private readonly IRepositoryPacientes repositorio;
        private readonly IUnidadDeTrabajo unitOfWork;

        public CasoDeUsoComandoActualizarPaciente(
            IRepositoryPacientes repositorioPaciente,
            IUnidadDeTrabajo unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
            this.repositorio = repositorioPaciente;
        }

        public async Task Handle(ComandoActualizarPaciente request)
        {
            var paciente = await repositorio.ObtenerPorId(request.Id);

            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            paciente.actualizarNombre(request.Nombre);
            paciente.actualizarEmail(new(request.Email));

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
