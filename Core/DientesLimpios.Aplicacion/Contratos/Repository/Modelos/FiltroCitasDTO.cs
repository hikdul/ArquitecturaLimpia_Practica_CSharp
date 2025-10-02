using DientesLimpios.Dominio.Enums;

namespace DientesLimpios.Aplicacion.Contratos.Repository
{
    public class FiltroCitasDTO
    {
        public Guid? PacienteId { get; set; }
        public Guid? DentistaId { get; set; }
        public Guid? ConsultorioId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public EstadoCita? EstadoCita { get; set; }
    }
}
