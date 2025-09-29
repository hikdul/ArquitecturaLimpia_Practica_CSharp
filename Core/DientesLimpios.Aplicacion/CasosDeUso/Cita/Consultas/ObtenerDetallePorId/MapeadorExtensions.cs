namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerDetallePorID
{
    public static class MapeadorExtensions
    {
        public static CItaDetalleDTO aDto(this DientesLimpios.Dominio.Entidades.Cita cita)
        {
            var dto = new CItaDetalleDTO()
            {
                Id = cita.Id,
                Estado = cita.Estado,
                IntervaloDeTiempo = cita.IntervaloDeTiempo,
                Consultorio_Nombre = cita.Consultorio?.Nombre ?? "",
                Paciente_Nombre = cita.Paciente?.Nombre ?? "",
                Dentista_Nombre = cita.Dentista?.Nombre ?? "",
            };

            return dto;
        }
    }
}
