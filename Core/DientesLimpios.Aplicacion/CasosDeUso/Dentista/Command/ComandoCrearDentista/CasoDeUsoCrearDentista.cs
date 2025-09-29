using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearDentista
{
    public class CasoDeUsoCrearDentista : IRequestHandler<ComandoCrearDentista, Guid>
    {
        private readonly IRepositoryDentista repository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoCrearDentista(
            IRepositoryDentista repository,
            IUnidadDeTrabajo unidadDeTrabajo
        )
        {
            this.repository = repository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoCrearDentista command)
        {
            var email = new Email(command.Email);
            Dentista dentista = new(command.Nombre, email);

            try
            {
                var resp = await repository.Agregar(dentista);
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
