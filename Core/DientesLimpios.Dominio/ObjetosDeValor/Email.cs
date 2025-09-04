
using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.ObjetosDeValor
{
    public record Email
    {
        public string Valor { get; }
         
         public Email(string email)
         {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new EXcepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio ");
            }

            if(!email.Contains("@"))
            {
                throw new EXcepcionDeReglaDeNegocio($"El {nameof(email)} no parece un email valido ");
            }
            this.Valor = email;
        }
    }
}