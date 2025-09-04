using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ConsultorioTest
    {
        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_nombreNulo_throwEx()
        {
            new Consultorio(null);
        }
    }
}
