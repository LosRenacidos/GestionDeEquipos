using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using RestCrudFull.Dominio;

namespace RestCrudFull
{
    [ServiceContract]
    public interface IGestionAverias
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "AAveria", ResponseFormat = WebMessageFormat.Json)]
        Averia AsignarProveedor(Averia averiaAAsignar);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CAveria", ResponseFormat = WebMessageFormat.Json)]
        Averia CerrarAveria(Averia averiaACerrar);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CoAveria", ResponseFormat = WebMessageFormat.Json)]
        Averia ConfirmarReparacion(Averia averiaAConfirmar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CaAveria", ResponseFormat = WebMessageFormat.Json)]
        void Cargarpendientes();
    }
}
