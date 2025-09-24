using System;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    public static class MapeadorExtensions
    {
        public static PacienteDetalleDTO ADto(
            this DientesLimpios.Dominio.Entidades.Paciente paciente
        )
        {
            var dto = new PacienteDetalleDTO
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Email = paciente.Email.Valor,
            };
            return dto;
        }
    }
}
