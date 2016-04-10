using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionEquipoWeb.Tests
{
    class Averia
    {
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaCierre { get; set; }
        public String Proveedor { get; set; }
        public int CodigoEquipo { get; set; }
        public String TecnicoAsignado { get; set; }
        public String TipoReparacion { get; set; }
        public String Descripcion { get; set; }
    }
}
