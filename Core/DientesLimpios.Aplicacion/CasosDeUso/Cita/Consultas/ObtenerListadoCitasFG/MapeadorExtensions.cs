namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListadoFG
{
    public static class MapeadorExtensions
    {
        public static CitaListadoDTO aDto(this DientesLimpios.Dominio.Entidades.Cita cita)
        {
            var dto = new CitaListadoDTO
            {
                Id = cita.Id,
                Paciente = cita.Paciente.Nombre,
                Consultorio = cita.Consultorio.Nombre,
                Dentista = cita.Dentista.Nombre,
                EstadoCita = cita.Estado.ToString(),
                Inicio = cita.IntervaloDeTiempo.Inicio,
                Fin = cita.IntervaloDeTiempo.Fin,
            };

            return dto;
        }
    }
}
