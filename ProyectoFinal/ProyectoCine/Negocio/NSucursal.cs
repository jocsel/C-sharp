using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
   public class NSucursal
    {
        public List<ESucursal> obtenerSucursal()
        {
            try
            {
                DSucursal datpsSucu = new DSucursal();
                return datpsSucu.obtenerSucursal();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
