using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RestCrudFull.Dominio;
using RestCrudFull.Persistencia;
using System.Net;
using System.ServiceModel.Web;

namespace RestCrudFull
{
    public class Averias : IAverias
    {
        private AveriaDAO dao = new AveriaDAO();

        public Averia CrearAveria(Averia averiaACrear)
        {
           Averia item= dao.Obtener(averiaACrear.Codigo);
            if(item!=null)
                throw new WebFaultException<string>("Codigo ya existe", HttpStatusCode.InternalServerError);

         
            return dao.Crear(averiaACrear);
        }

        public Averia ObtenerAveria(string codigo)
        {
            return dao.Obtener(int.Parse(codigo));
        }

        public Averia ModificarAveria(Averia averiaAModificar)
        {
            
            //Averia item = dao.Obtener(averiaAModificar.Codigo);
            //if (item.CodigoEquipo == averiaAModificar.CodigoEquipo)
            //    throw new WebFaultException<string>("Serie duplicada", HttpStatusCode.InternalServerError);
            if ("777".Equals(averiaAModificar.Codigo.ToString()))
            {
                throw new WebFaultException<string>("Serie duplicada", HttpStatusCode.NotAcceptable);
            }
            return dao.Modificar(averiaAModificar);
        }

        public void EliminarAveria(string codigo)
        {
            dao.Eliminar(int.Parse(codigo));
        }

        public List<Averia> ListarAverias()
        {
            return dao.ListarTodos();
        }
    }
}
