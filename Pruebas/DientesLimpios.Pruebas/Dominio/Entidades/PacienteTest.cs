using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class PacienteTest
    {
        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_nombreNulo_throwEx()
        {
            var email = new Email("hik@main.ve");
            new Paciente(null, email);
        }

        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_EmailNulo_throwEx()
        {
            new Paciente("nomber", null);
        }

        [TestMethod]
        [ExpectedException(typeof(EXcepcionDeReglaDeNegocio))]
        public void ctor_allNull_throwEx()
        {
            new Paciente(null, null);
        }
    }
}
