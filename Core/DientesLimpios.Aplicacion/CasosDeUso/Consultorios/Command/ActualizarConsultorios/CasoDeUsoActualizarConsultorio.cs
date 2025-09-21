using System;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios
{
    public class CasoDeUsoActualizarConsultorio : IRequestHandler<ComandoActualizarConsultorio>
    {
        private readonly IRepositoryConsultorios Repolsitorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarConsultorio(
            IRepositoryConsultorios repositorioConsultorio,
            IUnidadDeTrabajo unidadDeTrabajo
        )
        {
            this.Repolsitorio = repositorioConsultorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarConsultorio request)
        {
            var consultorio = await Repolsitorio.ObtenerPorId(request.Id);
            if (consultorio == null)
            {
                throw new ExcepcionNoEncontrado();
            }

            consultorio.Actualizar(request.Nombre);

            try
            {
                await Repolsitorio.Actualizar(consultorio);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
