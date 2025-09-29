using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Actualizar
{
    public class ComandoActualizarCita : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Guid DentistaId { get; set; }
        public Guid ConsultorioId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
