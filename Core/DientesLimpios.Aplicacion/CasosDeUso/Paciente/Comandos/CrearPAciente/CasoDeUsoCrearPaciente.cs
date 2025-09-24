using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.CrearPaciente
{
    public class CasoDeUsoCrearPaciente : IRequestHandler<ComandoCrearPaciente, Guid>
    {
        private readonly IRepositoryPacientes repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoCrearPaciente(
            IRepositoryPacientes repository,
            IUnidadDeTrabajo unidadDeTrabajo
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoCrearPaciente command)
        {
            var email = new Email(command.Email);
            Dominio.Entidades.Paciente paciente = new(command.Nombre, email);

            try
            {
                var resp = await repository.Agregar(paciente);
                await unidadDeTrabajo.Persistir();
                return resp.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
