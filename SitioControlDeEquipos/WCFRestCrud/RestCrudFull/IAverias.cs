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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAverias" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAverias
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Averias", ResponseFormat = WebMessageFormat.Json)]
        Averia CrearAveria(Averia averiaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Averias/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Averia ObtenerAveria(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Averias", ResponseFormat = WebMessageFormat.Json)]
        Averia ModificarAveria(Averia averiaAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Averias/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarAveria(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Averias", ResponseFormat = WebMessageFormat.Json)]
        List<Averia> ListarAverias();
    }
}
