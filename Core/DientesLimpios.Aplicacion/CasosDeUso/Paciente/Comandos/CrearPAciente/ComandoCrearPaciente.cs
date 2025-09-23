using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.CrearPaciente
{
    public class ComandoCrearPaciente : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
