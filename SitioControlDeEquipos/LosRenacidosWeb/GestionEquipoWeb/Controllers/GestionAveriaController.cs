using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionEquipoWeb.Models;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace GestionEquipoWeb.Controllers
{
    public class GestionAveriaController : Controller
    {
        //
        // GET: /GestionAveria/

        private List<Averia> CrearAverias()
        {
            //List<Averia> averias = new List<Averia>();
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
             .Create("http://localhost:41782/Averias.svc/Averias");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string averiaJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<Averia> averiasObtenido = js2.Deserialize<List<Averia>>(averiaJson2);
            //averias.Add(new Averia() {Codigo=1,Estado="Ingresado",FechaRegistro="03-02-2016",FechaCierre="23-03-2016",Proveedor="Cosapi", CodigoEquipo= 1001,TecnicoAsignado="Yuri Mateo",TipoReparacion="Garantia",Descripcion="Cambio de CPU" });
            //averias.Add(new Averia() { Codigo = 2, Estado = "Ingresado", FechaRegistro = "04-02-2016", FechaCierre = "24-03-2016", Proveedor = "Cosapi", CodigoEquipo = 1002, TecnicoAsignado = "Frank Guerra", TipoReparacion = "Garantia", Descripcion = "Cambio de Maimboard" });
            //averias.Add(new Averia() { Codigo = 3, Estado = "Ingresado", FechaRegistro = "05-02-2016", FechaCierre = "20-03-2016", Proveedor = "Cosapi", CodigoEquipo = 1003, TecnicoAsignado = "Edward Zenozain", TipoReparacion = "Garantia", Descripcion = "Cambio de Fuente" });

            return averiasObtenido;
        }
        private Averia ObtenerAveria(int codigo)
        {
            List<Averia> averias = (List<Averia>)Session["averias"];
            Averia model = averias.Single(delegate(Averia averia)
            {
                if (averia.Codigo == codigo) return true;
                else return false;
            });
            return model;
        }
        //
        // GET: /Averia/

        public ActionResult Index()
        {
            if (Session["averias"] == null)
                Session["averias"] = CrearAverias();
            List<Averia> model = (List<Averia>)Session["averias"];
            return View(model);
        }

        //
        

        //
        // GET: /Averia/Create

        public ActionResult Asignar(int id)
        {
            Averia model = ObtenerAveria(id);
            return View();
        }

        //
        // POST: /Averia/Create

        [HttpPost]
        public ActionResult Asignar(int id, FormCollection collection)
        {
            try
            {

                Averia model = ObtenerAveria(id);

                string postdata = "{\"Codigo\":\"" + collection["Codigo"] + "\",\"Estado\":\"" + collection["Estado"] + "\",\"FechaRegistro\":\"" + collection["FechaRegistro"] + "\",\"FechaCierre\":\"" + collection["FechaCierre"] + "\",\"Proveedor\":\"" + collection["Proveedor"] + "\",\"CodigoEquipo\":\"" + collection["CodigoEquipo"] + "\",\"TecnicoAsignado\":\"" + collection["TecnicoAsignado"] + "\",\"TipoReparacion\":\"" + collection["TipoReparacion"] + "\",\"Descripcion\":\"" + collection["Descripcion"] + "\"}"; //JSON
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:41782/GestionAverias.svc/AAveria");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                model.Codigo = int.Parse(collection["Codigo"]);
                model.Proveedor = collection["Proveedor"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Averia/Edit/5

        public ActionResult Cerrar(int id)
        {
            Averia model = ObtenerAveria(id);
            return View(model);
        }

        //
        // POST: /Averia/Edit/5

        [HttpPost]
        public ActionResult Cerrar(int id, FormCollection collection)
        {
            try
            {

                Averia model = ObtenerAveria(id);

                string postdata = "{\"Codigo\":\"" + collection["Codigo"] + "\",\"Estado\":\"" + collection["Estado"] + "\",\"FechaRegistro\":\"" + collection["FechaRegistro"] + "\",\"FechaCierre\":\"" + collection["FechaCierre"] + "\",\"Proveedor\":\"" + collection["Proveedor"] + "\",\"CodigoEquipo\":\"" + collection["CodigoEquipo"] + "\",\"TecnicoAsignado\":\"" + collection["TecnicoAsignado"] + "\",\"TipoReparacion\":\"" + collection["TipoReparacion"] + "\",\"Descripcion\":\"" + collection["Descripcion"] + "\"}"; //JSON
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:41782/Averias.svc/Averias");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);


                model.Estado = collection["Estado"];
                model.FechaRegistro = collection["FechaRegistro"];
                model.FechaCierre = collection["FechaCierre"];
                model.Proveedor = collection["Proveedor"];
                model.CodigoEquipo = int.Parse(collection["CodigoEquipo"]);
                model.TecnicoAsignado = collection["TecnicoAsignado"];
                model.TipoReparacion = collection["TipoReparacion"];
                model.Descripcion = collection["Descripcion"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Averia/Delete/5

        public ActionResult Confirmar(int id)
        {
            Averia model = ObtenerAveria(id);
            return View(model);
        }

        //
        // POST: /Averia/Delete/5

        [HttpPost]
        public ActionResult Confirmar(int id, FormCollection collection)
        {
            try
            {

                List<Averia> averias = (List<Averia>)Session["averias"];

                String eliminarCodigo = (string)id.ToString();

                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:41782/Averias.svc/Averias/" + eliminarCodigo);
                req.Method = "DELETE";

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                averias.Remove(ObtenerAveria(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GestionAveria/Details/5

    }
}
