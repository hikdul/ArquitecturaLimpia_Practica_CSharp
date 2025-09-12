using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio
{
    public static class MapeadorExtensions
    {
        public static ConsultarioDetalleDTO ADto(this Consultorio consultorio)
        {
            var dto = new ConsultarioDetalleDTO
            {
                Id = consultorio.Id,
                Nombre = consultorio.Nombre,
            };
            return dto;
        }
    }
}
