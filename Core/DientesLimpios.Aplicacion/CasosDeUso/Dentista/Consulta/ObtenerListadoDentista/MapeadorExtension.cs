
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Consultas.ObtenerListadoDentista
{
    public static class MapeadorExtension
    {
        public static Dentista_out aDto(this Dentista d)
        {
            return new Dentista_out()
            {
                Nombre = d.Nombre,
                Email = d.Email.Valor,
                Id = d.Id,
            };
        }
    }
}