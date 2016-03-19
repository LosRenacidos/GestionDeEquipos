using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WCFServicios.Dominio
{
    [DataContract]

    public class Equipo
    {
        [DataMember]
        public int codigo_equipo { get; set; }
        [DataMember]
        public string marca_equipo { get; set; }
        [DataMember]
        public string modelo_equipo { get; set; }
        [DataMember(IsRequired=false)]
        public string descripcion_equipo { get; set; }
       [DataMember]
        public string serie_equipo { get; set; }
       [DataMember]
       public string responsable_equipo { get; set; }
       [DataMember]
       public string ubicacion_equipo { get; set; }



    }
}