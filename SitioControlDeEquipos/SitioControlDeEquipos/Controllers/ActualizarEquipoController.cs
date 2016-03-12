using SitioControlDeEquipos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioControlDeEquipos.Controllers
{
    public class ActualizarEquipoController : Controller
    {
        private List<Equipo> CrearEquipos()
        {
            List<Equipo>  equipos  =new List<Equipo>();
            equipos.Add(new Equipo(){codigo_equipo=1,marca="DELL",modelo="Latitude 3410",numero_serie="C0542P",descripcion="14 pulgadas, Intel Core I5 4570 2.7GHz, 4GB DDR3 13333 , 500GB HDD 7200RPM",responsable="Javier Diaz",ubicacion="Almacen Lima"});
            equipos.Add(new Equipo(){codigo_equipo=2,marca="ACER",modelo="ASPIRE 700",numero_serie="C0540A",descripcion="14 pulgadas, Intel Core I3 3220 2.8GHz, 8GB DDR3 13333 , 3200GB HDD 7200RPM",responsable="Alex Ramos",ubicacion="Oficina Lima"});
            equipos.Add(new Equipo(){codigo_equipo=3,marca="HP",modelo="450",numero_serie="C054BB",descripcion="14 pulgadas, Intel Core I5 4570 2.2GHz, 6GB DDR3 13333 , 500GB HDD 7200RPM",responsable="Oscar Aguilar",ubicacion="Almacen Chiclayo"});
            equipos.Add(new Equipo(){codigo_equipo=4,marca="LENOVO",modelo="M490S",numero_serie="C05JJS",descripcion="14 pulgadas, Intel Core I7 4770 3.0GHz, 8GB DDR3 13333 , 750GB HDD 7200RPM",responsable="Felipe Castilla",ubicacion="Oficina Surco"});
            equipos.Add(new Equipo() { codigo_equipo = 5, marca = "DELL", modelo = "Latitude 5410", numero_serie = "T0542P", descripcion = "14 pulgadas, Intel Core I3 4130 2.0GHz, 4GB DDR3 13333 , 500GB HDD 7200RPM", responsable = "Lenin Carrasco", ubicacion = "Oficina Callao" });
            int cantidad = equipos.Count;
            return equipos;

        }
        private Equipo obtenerEquipo(int codigo)
            {
                List<Equipo> equipos = (List<Equipo>)Session["equipos"];
                Equipo model = equipos.Single(delegate(Equipo equipo)
                {
                    if (equipo.codigo_equipo == codigo) return true;
                    else return false;
                });
                return model;
            }

        // GET: /ActualizarEquipo/

        public ActionResult Index()
        {
            if (Session["equipos"] == null)
                Session["equipos"] = CrearEquipos();
            List<Equipo> model = (List<Equipo>)Session["equipos"];
            
            return View(model);
        }

        //
        // GET: /ActualizarEquipo/Details/5

        public ActionResult Details(int id)
        {
            Equipo model = obtenerEquipo(id);
            return View(model);
        }

        //
        // GET: /ActualizarEquipo/Create

        public ActionResult Create()
        {
            
            return View();
        }

        //
        // POST: /ActualizarEquipo/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                List<Equipo> equipos = (List<Equipo>)Session["equipos"];
                equipos.Add(new Equipo()
                {
                    codigo_equipo = int.Parse(collection["codigo_equipo"]),
                    marca = collection["marca"],
                    modelo = collection["modelo"],
                    numero_serie = collection["numero_serie"],
                    descripcion = collection["descripcion"],
                    responsable = collection["responsable"],
                    ubicacion = collection["ubicacion"],
                });
                  
                return RedirectToAction("Index");
            
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ActualizarEquipo/Edit/5

        public ActionResult Edit(int id)
        {

            Equipo model = obtenerEquipo(id);
            return View(model);
        }

        //
        // POST: /ActualizarEquipo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Equipo model = obtenerEquipo(id);
                
                model.marca = collection["Marca"];
                model.modelo = collection["Modelo"];
                model.numero_serie = collection["Numero de serie"];
                model.descripcion = collection["Descripcion"];
                model.responsable = collection["Responsable"];
                model.ubicacion = collection["Ubicacion"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ActualizarEquipo/Delete/5

        public ActionResult Delete(int id)
        {
            Equipo model = obtenerEquipo(id);
            return View(model);
        }

        //
        // POST: /ActualizarEquipo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<Equipo> equipos = (List<Equipo>)Session["equipos"];
                equipos.Remove(obtenerEquipo(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

    }
}
