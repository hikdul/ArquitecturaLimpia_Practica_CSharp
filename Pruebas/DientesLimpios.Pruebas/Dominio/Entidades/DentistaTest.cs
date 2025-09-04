using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class DentistaTest
    {
        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_nombreNulo_throwEx()
        {
            var email = new Email("hik@main.ve");
            new Dentista(null, email);
        }

        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_EmailNulo_throwEx()
        {
            new Dentista("nomber", null);
        }

        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_allNull_throwEx()
        {
            new Dentista(null, null);
        }
    }
}
