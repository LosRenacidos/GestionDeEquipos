using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RestCrudFull.Persistencia;
using RestCrudFull.Dominio;
using System.ServiceModel.Web;
using System.Net;
using System.Messaging;

namespace RestCrudFull
{
  public class GestionAverias : IGestionAverias
    {
      private GestionAveriaDAO dao = new GestionAveriaDAO();

      public Averia AsignarProveedor(Averia averiaAAsignar)
      {
          Averia item = dao.Obtener(averiaAAsignar.Codigo);
          if (item.Estado == "Asignado")
              throw new WebFaultException<string>("Averia ya fue asignada", HttpStatusCode.InternalServerError);

          return dao.ModificarAveria(averiaAAsignar);
      }
      public Averia CerrarAveria(Averia averiaACerrar)
      {
          Averia item = dao.Obtener(averiaACerrar.Codigo);
          if (item.Estado == "Cerrada")
              throw new WebFaultException<string>("Averia ya fue cerrada", HttpStatusCode.InternalServerError);

          return dao.ModificarAveria(averiaACerrar);
      }
      public Averia ConfirmarReparacion(Averia averiaAConfirmar)
      {
          Averia item = dao.Obtener(averiaAConfirmar.Codigo);
          if (item.Estado == "Reparado")
              throw new WebFaultException<string>("Averia ya fue reparado", HttpStatusCode.InternalServerError);

          return dao.ModificarAveria(averiaAConfirmar);
      }

      public void Cargarpendientes()
      {
          String rutaCola = @".\private$\pendientes";
          if (!MessageQueue.Exists(rutaCola))
              MessageQueue.Create(rutaCola);
          MessageQueue cola = new MessageQueue(rutaCola);
          cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Averia) });
          int cantidad = cola.GetAllMessages().Count();
          for (int i = 0; i < cantidad; i++)
          {
              Message mensaje = cola.Receive();
              Averia averia = (Averia)mensaje.Body;
              dao.ModificarAveria(averia);
  
          }

      }

    }
}
