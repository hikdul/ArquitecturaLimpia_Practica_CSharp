using System;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    public class PacienteDetalleDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}