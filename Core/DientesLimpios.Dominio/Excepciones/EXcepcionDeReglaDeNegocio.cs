
using System;

namespace DientesLimpios.Dominio.Excepciones
{
    public class EXcepcionDeReglaDeNegocio : Exception
    {
        public EXcepcionDeReglaDeNegocio(string message): base(message)
        {
            
        }
    }
}