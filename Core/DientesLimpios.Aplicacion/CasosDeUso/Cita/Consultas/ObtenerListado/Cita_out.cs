using DientesLimpios.Dominio.Enums;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListado
{
    public class Cita_out
    {
        public Guid Id { get; set; }

        public string Paciente_Nombre { get; set; }

        public string Dentista_Nombre { get; set; }

        public string Consultorio_Nombre { get; set; }

        public EstadoCita Estado { get; set; }

        public IntervaloDeTiempo IntervaloDeTiempo { get; set; } = null;
    }
}