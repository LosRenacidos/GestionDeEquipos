using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RestCrudFull.Dominio
{
    [DataContract]
    public class Averia
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string FechaRegistro { get; set; }
        [DataMember]
        public string FechaCierre { get; set; }
        [DataMember]
        public String Proveedor { get; set; }
        [DataMember]
        public int CodigoEquipo { get; set; }
        [DataMember]
        public String TecnicoAsignado { get; set; }
        [DataMember]
        public String TipoReparacion { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
    }
}