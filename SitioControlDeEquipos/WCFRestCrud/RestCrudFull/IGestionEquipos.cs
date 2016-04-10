using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestCrudFull
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGestionEquipos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGestionEquipos
    {
        [OperationContract]
        void DoWork();
    }
}
