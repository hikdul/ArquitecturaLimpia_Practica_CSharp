using System;

namespace DientesLimpios.Aplicacion.Excepcion
{
    public class ExcepcionDeMediador : Exception
    {
        public ExcepcionDeMediador(string Message)
            : base(Message) { }
    }
}
