//using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas
{
    public static class MapeadorExtensions
    {
        public static PacienteListadoDTO Adto(
            this DientesLimpios.Dominio.Entidades.Paciente paciente
        )
        {
            var dto = new PacienteListadoDTO
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Email = paciente.Email.Valor,
            };
            return dto;
        }
    }
}
