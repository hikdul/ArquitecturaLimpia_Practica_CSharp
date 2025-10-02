using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Recordar
{
    public static class MapeadorExtention
    {
        public static RecordatorioCitaDTO aDto(this DientesLimpios.Dominio.Entidades.Cita cita)
        {
            return new RecordatorioCitaDTO
            {
                Id = cita.Id,
                Paciente = cita.Paciente.Nombre,
                Paciente_Email = cita.Paciente.Email.Valor,
                Dentista = cita.Dentista.Nombre,
                Consultorio = cita.Consultorio.Nombre,
                Fecha = cita.IntervaloDeTiempo.Inicio,
            };
        }
    }
}
