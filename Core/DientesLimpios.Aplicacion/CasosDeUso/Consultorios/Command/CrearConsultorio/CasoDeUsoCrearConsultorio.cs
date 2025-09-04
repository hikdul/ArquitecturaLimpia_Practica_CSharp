using System;
using DientesLimpios.Aplicacion.Contratos.Repository;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio
    {
        private readonly IRepositoryConsultorios repository;

        public CasoDeUsoCrearConsultorio(IRepositoryConsultorios repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> Handle(CommandCrearConsultorio command)
        {
            var consultorio = new Consultorio(command.Nombre);
            var resp = await repository.Agregar(consultorio);
            return resp.Id;
        }
    }
}
