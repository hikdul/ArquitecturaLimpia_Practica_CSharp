using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.ActualizarPaciente
{
    public class ComandoActualizarPaciente : IRequest
    {
        public required Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
    }
}
