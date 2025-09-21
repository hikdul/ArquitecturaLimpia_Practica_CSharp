using System;
using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.Entidades
{
    public class Consultorio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null;

        public Consultorio(string nombre)
        {
            AplicarReglasDeNegocio(nombre);

            this.Nombre = nombre;
            Id = Guid.CreateVersion7();
        }

        public void Actualizar(string nombre)
        {
            AplicarReglasDeNegocio(nombre);

            this.Nombre = nombre;
        }

        private void AplicarReglasDeNegocio(string Nombre)
        {
            AplicarReglasDeNegocioNombre(Nombre);
        }

        private void AplicarReglasDeNegocioNombre(string Nombre)
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new EXcepcionDeReglaDeNegocio($"El {nameof(Nombre)} es obligatorio ");
            }
        }
    }
}
