using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicios.Persistencia;
using WCFServicios.Dominio;
using WCFServicios.Errores;

namespace WCFServicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Equipos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Equipos.svc or Equipos.svc.cs at the Solution Explorer and start debugging.
    public class Equipos : IEquipos
    {
        private EquipoDAO equipoDAO = new EquipoDAO();


        public Equipo CrearEquipo(Dominio.Equipo equipoACrear)
        {
           
           return equipoDAO.Crear(equipoACrear);
        }

        public Equipo ObtenerEquipo(int codigo_equipo)
        {
            return equipoDAO.Obtener(codigo_equipo);
        }

        public Equipo ModificarEquipo(Equipo equipoAModificar)
        {
            return equipoDAO.Modificar(equipoAModificar);
        }

        public void EliminarEquipo(int codigo_equipo)
        {
            equipoDAO.Eliminar(codigo_equipo);
        }

        public List<Equipo> ListarEquipos()
        {
            return equipoDAO.Listar();
        }
    }
}
