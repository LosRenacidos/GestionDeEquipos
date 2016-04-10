using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace GestionEquipoWeb.Tests
{
    /// <summary>
    /// Descripción resumida de TestGestion
    /// </summary>
    [TestClass]
    public class TestGestion
    {
        public TestGestion()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CRUDTest()
        {
            string nuevoCodigo = "4";
            // Prueba de creación de equipo vía HTTP POST
            string postdata = "{\"Codigo\":\"" + nuevoCodigo + "\",\"Estado\":\"Ingresado\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"1001\",\"TecnicoAsignado\":\"Yuri Mateo\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string averiaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Averia averiaCreado = js.Deserialize<Averia>(averiaJson);
            Assert.AreEqual(int.Parse(nuevoCodigo), averiaCreado.Codigo);
            Assert.AreEqual("Ingresado", averiaCreado.Estado);
            Assert.AreEqual("0300302016", averiaCreado.FechaRegistro);
            Assert.AreEqual("2300302016", averiaCreado.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaCreado.Proveedor);
            Assert.AreEqual(int.Parse("1001"), averiaCreado.CodigoEquipo);
            Assert.AreEqual("Yuri Mateo", averiaCreado.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaCreado.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaCreado.Descripcion);

            // Prueba de obtención de equipo vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias/" + nuevoCodigo);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string averiaJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Averia averiaObtenido = js2.Deserialize<Averia>(averiaJson2);
            Assert.AreEqual(int.Parse(nuevoCodigo), averiaObtenido.Codigo);
            Assert.AreEqual("Ingresado", averiaObtenido.Estado);
            Assert.AreEqual("0300302016", averiaObtenido.FechaRegistro);
            Assert.AreEqual("2300302016", averiaObtenido.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaObtenido.Proveedor);
            Assert.AreEqual(int.Parse("1001"), averiaObtenido.CodigoEquipo);
            Assert.AreEqual("Yuri Mateo", averiaObtenido.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaObtenido.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaObtenido.Descripcion);

        }

        [TestMethod]
        public void CrearEquipoErrorTest()
        {
            string nuevoCodigo = "2";
            // Prueba de creación de equipo vía HTTP POST
            string postdata = "{\"Codigo\":\"" + nuevoCodigo + "\",\"Estado\":\"Ingresado\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"1001\",\"TecnicoAsignado\":\"Yuri Mateo\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            //HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //StreamReader reader = new StreamReader(res.GetResponseStream());
            //string equipoJson = reader.ReadToEnd();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Equipo equipoCreado = js.Deserialize<Equipo>(equipoJson);
            //Assert.AreEqual(nuevoCodigo, equipoCreado.Codigo);
            //Assert.AreEqual("IBM", equipoCreado.Marca);
            //Assert.AreEqual("ThinkPad501", equipoCreado.Modelo);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string averiaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Averia averiaCreado = js.Deserialize<Averia>(averiaJson);

                Assert.AreEqual(int.Parse(nuevoCodigo), averiaCreado.Codigo);
                Assert.AreEqual("Ingresado", averiaCreado.Estado);
                Assert.AreEqual("0300302016", averiaCreado.FechaRegistro);
                Assert.AreEqual("2300302016", averiaCreado.FechaCierre);
                Assert.AreEqual("Cosapi2", averiaCreado.Proveedor);
                Assert.AreEqual(int.Parse("1001"), averiaCreado.CodigoEquipo);
                Assert.AreEqual("Yuri Mateo", averiaCreado.TecnicoAsignado);
                Assert.AreEqual("Garantia", averiaCreado.TipoReparacion);
                Assert.AreEqual("Cambio de CPU", averiaCreado.Descripcion);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Codigo ya existe", mensaje);
            }
        }
        [TestMethod]
        public void ModificarEquipoErrorTest()
        {
            string nuevoCodigo = "777";
            // Prueba de modificación de equipo vía HTTP POST
            string postdata = "{\"Codigo\":\"" + nuevoCodigo + "\",\"Estado\":\"Ingresado\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"1001\",\"TecnicoAsignado\":\"Eduardo Blest\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string averiaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Averia averiaCreado = js.Deserialize<Averia>(averiaJson);
                Assert.AreEqual(int.Parse(nuevoCodigo), averiaCreado.Codigo);
                Assert.AreEqual("Ingresado", averiaCreado.Estado);
                Assert.AreEqual("0300302016", averiaCreado.FechaRegistro);
                Assert.AreEqual("2300302016", averiaCreado.FechaCierre);
                Assert.AreEqual("Cosapi2", averiaCreado.Proveedor);
                Assert.AreEqual(int.Parse("1001"), averiaCreado.CodigoEquipo);
                Assert.AreEqual("Eduardo Blest", averiaCreado.TecnicoAsignado);
                Assert.AreEqual("Garantia", averiaCreado.TipoReparacion);
                Assert.AreEqual("Cambio de CPU", averiaCreado.Descripcion);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Serie duplicada", mensaje);
            }


        }

        [TestMethod]
        public void ModificarEquipoTest()
        {
            string postdata = "{\"Codigo\":\"3\",\"Estado\":\"Ingresado\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"3003\",\"TecnicoAsignado\":\"Eduardo Blest\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string averiaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Averia averiaModificado = js.Deserialize<Averia>(averiaJson);
            Assert.AreEqual(3, averiaModificado.Codigo);
            Assert.AreEqual("Ingresado", averiaModificado.Estado);
            Assert.AreEqual("0300302016", averiaModificado.FechaRegistro);
            Assert.AreEqual("2300302016", averiaModificado.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaModificado.Proveedor);
            Assert.AreEqual(int.Parse("3003"), averiaModificado.CodigoEquipo);
            Assert.AreEqual("Eduardo Blest", averiaModificado.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaModificado.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaModificado.Descripcion);
        }

        [TestMethod]
        public void EliminarEquipoTest()
        {
            string eliminarCogido = "4";
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias/" + eliminarCogido);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias/" + eliminarCogido);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string averiaJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Averia averiaEliminado = js2.Deserialize<Averia>(averiaJson2);
            Assert.IsNull(averiaEliminado);
        }

        [TestMethod]
        public void asignarAveriaTest()
        {
            string postdata = "{\"Codigo\":\"3\",\"Estado\":\"Asignado\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"3003\",\"TecnicoAsignado\":\"Eduardo Blest\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/GestionAverias.svc/AAveria");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string averiaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Averia averiaModificado = js.Deserialize<Averia>(averiaJson);
            Assert.AreEqual(3, averiaModificado.Codigo);
            Assert.AreEqual("Asignado", averiaModificado.Estado);
            Assert.AreEqual("0300302016", averiaModificado.FechaRegistro);
            Assert.AreEqual("2300302016", averiaModificado.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaModificado.Proveedor);
            Assert.AreEqual(int.Parse("3003"), averiaModificado.CodigoEquipo);
            Assert.AreEqual("Eduardo Blest", averiaModificado.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaModificado.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaModificado.Descripcion);
        }

        [TestMethod]
        public void cerrarAveriaTest()
        {
            string postdata = "{\"Codigo\":\"2\",\"Estado\":\"Cerrada\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"3003\",\"TecnicoAsignado\":\"Eduardo Blest\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/GestionAverias.svc/CAveria");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string averiaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Averia averiaModificado = js.Deserialize<Averia>(averiaJson);
            Assert.AreEqual(2, averiaModificado.Codigo);
            Assert.AreEqual("Cerrada", averiaModificado.Estado);
            Assert.AreEqual("0300302016", averiaModificado.FechaRegistro);
            Assert.AreEqual("2300302016", averiaModificado.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaModificado.Proveedor);
            Assert.AreEqual(int.Parse("3003"), averiaModificado.CodigoEquipo);
            Assert.AreEqual("Eduardo Blest", averiaModificado.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaModificado.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaModificado.Descripcion);
        }
        [TestMethod]
        public void confirmarReparacionAveriaTest()
        {
            string postdata = "{\"Codigo\":\"1\",\"Estado\":\"Reparada\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"3003\",\"TecnicoAsignado\":\"Eduardo Blest\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/GestionAverias.svc/CoAveria");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string averiaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Averia averiaModificado = js.Deserialize<Averia>(averiaJson);
            Assert.AreEqual(1, averiaModificado.Codigo);
            Assert.AreEqual("Reparada", averiaModificado.Estado);
            Assert.AreEqual("0300302016", averiaModificado.FechaRegistro);
            Assert.AreEqual("2300302016", averiaModificado.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaModificado.Proveedor);
            Assert.AreEqual(int.Parse("3003"), averiaModificado.CodigoEquipo);
            Assert.AreEqual("Eduardo Blest", averiaModificado.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaModificado.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaModificado.Descripcion);
        }
        [TestMethod]
        public void cargarPendientesTest()
        {
            string postdata = "{\"Codigo\":\"3\",\"Estado\":\"Reparada\",\"FechaRegistro\":\"0300302016\",\"FechaCierre\":\"2300302016\",\"Proveedor\":\"Cosapi2\",\"CodigoEquipo\":\"3003\",\"TecnicoAsignado\":\"Eduardo Blest\",\"TipoReparacion\":\"Garantia\",\"Descripcion\":\"Cambio de CPU\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/GestionAverias.svc/CaAveria");
            req.Method = "GET";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string averiaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Averia averiaModificado = js.Deserialize<Averia>(averiaJson);
            Assert.AreEqual(3, averiaModificado.Codigo);
            Assert.AreEqual("Reparada", averiaModificado.Estado);
            Assert.AreEqual("0300302016", averiaModificado.FechaRegistro);
            Assert.AreEqual("2300302016", averiaModificado.FechaCierre);
            Assert.AreEqual("Cosapi2", averiaModificado.Proveedor);
            Assert.AreEqual(int.Parse("3003"), averiaModificado.CodigoEquipo);
            Assert.AreEqual("Eduardo Blest", averiaModificado.TecnicoAsignado);
            Assert.AreEqual("Garantia", averiaModificado.TipoReparacion);
            Assert.AreEqual("Cambio de CPU", averiaModificado.Descripcion);
        }
    }
}
