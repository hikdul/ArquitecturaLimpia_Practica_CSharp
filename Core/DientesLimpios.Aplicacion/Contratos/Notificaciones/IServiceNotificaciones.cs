namespace DientesLimpios.Aplicacion.Contratos.Notificaciones
{
    public interface IServiceNotificaciones
    {
        Task EnviarConfirmacionCita(ConfirmacionCitaDTO cita);
        Task EnviarRecordatorioCita(RecordatorioCitaDTO cita);
    }
}
