using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Actualizar
{
    public class CasoDeUsoActualizarCita : IRequestHandler<ComandoActualizarCita, Guid>
    {
        private readonly IRepositoryCita repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarCita(IRepositoryCita repository, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoActualizarCita command)
        {
            var ent = await repository.ObtenerPorId(command.Id);

            if (ent is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            IntervaloDeTiempo it = new(command.Inicio, command.Fin);
            ent.UPIntervaloTiempo(it);
            ent.UpConsultorio(command.ConsultorioId);
            ent.UPDentista(command.DentistaId);
            ent.UPPaciente(command.PacienteId);

            try
            {
                await repository.Actualizar(ent);
                await unidadDeTrabajo.Persistir();
                return ent.Id;
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
