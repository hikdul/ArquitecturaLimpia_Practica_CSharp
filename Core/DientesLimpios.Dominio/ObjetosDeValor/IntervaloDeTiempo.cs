using System;
using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.ObjetosDeValor
{
    public record IntervaloDeTiempo
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }

        private IntervaloDeTiempo() { }

        public IntervaloDeTiempo(DateTime inicio, DateTime fin)
        {
            if (inicio >= fin)
            {
                throw new EXcepcionDeReglaDeNegocio($"Las fecha no son validas");
            }
            this.Inicio = inicio;
            this.Fin = fin;
        }
    }
}
