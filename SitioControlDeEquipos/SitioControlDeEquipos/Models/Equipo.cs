using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioControlDeEquipos.Models
{
    public class Equipo
    {


        public int codigo_equipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string numero_serie { get; set; }
        public string fecha_compra { get; set; }
        public string periodo_garantia { get; set; }
        public string descripcion { get; set; }
        public string responsable { get; set; }
        public string ubicacion { get; set; }

        public int canEq{
            get;
            set; 
        }
    }
}