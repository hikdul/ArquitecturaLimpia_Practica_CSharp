using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerDetallesDentista
{
    public static class MapeadorExtension
    {
        public static DentistaDetalle_out aDto(this Dentista d)
        {
            return new DentistaDetalle_out()
            {
                Nombre = d.Nombre,
                Email = d.Email.Valor,
                Id = d.Id,
            };
        }
    }
}
