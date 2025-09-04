using System;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void constructor_emailNulo_throwExcep()
        {
            new Email(null);
        }

        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void constructor_emailSinArroba_throwExcep()
        {
            new Email("hola");
        }

        [TestMethod]
        public void constructor_emailOK_NOthrowExcep()
        {
            new Email("hikdul.dev@main.ve");
        }
    }
}
