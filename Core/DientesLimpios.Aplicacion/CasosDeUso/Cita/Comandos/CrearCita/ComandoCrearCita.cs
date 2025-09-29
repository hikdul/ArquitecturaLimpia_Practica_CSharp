using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Crear
{
    public class ComandoCrearCita : IRequest<Guid>
    {
        public Guid PacienteId { get; set; }
        public Guid DentistaId { get; set; }
        public Guid ConsultorioId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
