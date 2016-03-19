using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicios.Dominio;
using WCFServicios.Errores;

namespace WCFServicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEquipos" in both code and config file together.
    [ServiceContract]
    public interface IEquipos
    {
        [FaultContract(typeof(RepetidoException))]

        [OperationContract]
        Equipo CrearEquipo(Equipo equipoACrear);
        [OperationContract]
        Equipo ObtenerEquipo(int codigo_equipo);
        [OperationContract]
        Equipo ModificarEquipo(Equipo equipoAModificar);
        [OperationContract]
        void EliminarEquipo(int codigo_equipo);
        [OperationContract]
        List<Equipo> ListarEquipos();
    }
}
