using System;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Dominio.Entidades
{
    public class Paciente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null;
        public Email Email { get; private set; } = null;

        private Paciente() { }
        public Paciente(string nombre, Email email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new EXcepcionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio ");
            }

            if (email is null)
            {
                throw new EXcepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio ");
            }

            this.Id = Guid.CreateVersion7();
            this.Email = email;
            this.Nombre = nombre;
        }
    }
}
