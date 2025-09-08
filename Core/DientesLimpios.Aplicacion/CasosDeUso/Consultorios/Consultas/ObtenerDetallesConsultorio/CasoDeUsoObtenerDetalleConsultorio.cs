using System;
using System.Threading.Tasks;
using DientesLimpios.Aplicacion.Contratos.Repository;
using DientesLimpios.Aplicacion.Excepcion;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio
{
    public class CasoDeUsoObtenerDetalleConsultorio
        : IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultarioDetalleDTO>
    {
        private readonly IRepositoryConsultorios repositorio;

        public CasoDeUsoObtenerDetalleConsultorio(IRepositoryConsultorios repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<ConsultarioDetalleDTO> Handle(ConsultaObtenerDetalleConsultorio request)
        {
            var consultorio = await repositorio.ObtenerPorId(request.Id);
            if (consultorio is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            var dto = new ConsultarioDetalleDTO
            {
                Id = consultorio.Id,
                Nombre = consultorio.Nombre,
            };
            return dto;
        }
    }
}
