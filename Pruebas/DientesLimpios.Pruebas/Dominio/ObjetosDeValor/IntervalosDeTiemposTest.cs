using System;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class IntervalosDeTiemposTest
    {
        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void Ctor_inicioPosterioFin_throw()
        {
            new IntervaloDeTiempo(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1));
        }

        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void Ctor_inicioEqualFin_throw()
        {
            var date = DateTime.UtcNow;
            new IntervaloDeTiempo(date, date);
        }

        [TestMethod]
        public void Ctor_OK()
        {
            new IntervaloDeTiempo(DateTime.UtcNow, DateTime.UtcNow.AddHours(1));
        }
    }
}
