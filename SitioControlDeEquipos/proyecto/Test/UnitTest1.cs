using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrearEquipoOK()
        {
            EquiposWS.EquiposClient proxy = new EquiposWS.EquiposClient();
            EquiposWS.Equipo equipoCreado= proxy.CrearEquipo(new EquiposWS.Equipo()

                {
                    codigo_equipo = 5,
                    marca_equipo = "DELL",
                    descripcion_equipo = "hhcccccc",
                    serie_equipo = "9000024"

                } );
            Assert.Equals(5, equipoCreado.codigo_equipo);
            Assert.Equals("DELL", equipoCreado.marca_equipo);
            Assert.Equals("hhcccccc", equipoCreado.descripcion_equipo);
            Assert.Equals("9000024", equipoCreado.serie_equipo);
        }

        [TestMethod]
        public void testCrearEquipoRepetido()
        {
            EquiposWS.EquiposClient proxy = new EquiposWS.EquiposClient();
            try { 
            EquiposWS.Equipo equipoCreado = proxy.CrearEquipo(new EquiposWS.Equipo()

            {
                codigo_equipo = 4,
                marca_equipo = "DELL",
                descripcion_equipo = "abcccccc",
                serie_equipo = "984324"

            });
        } catch(FaultException<EquiposWS.RepetidoException> error)
            {

            Assert.AreEqual("Error al intentar la creación",error.Reason.ToString());
            Assert.AreEqual(error.Detail.codigo,"888");
            Assert.AreEqual(error.Detail.descripcion,"El equipo ya existe");
        }

        }
}
}