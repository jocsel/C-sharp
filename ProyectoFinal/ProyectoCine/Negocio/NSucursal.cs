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

       public void Agregar (ESucursal nuevoSucursal)
        {
            try
            {
                if (nuevoSucursal.Nombre.Length == 0)
                    throw new ArgumentException("Ingrese el nombre del Sucursal");
                if (nuevoSucursal.Ciudad.Length == 0)
                    throw new ArgumentException("Íngrese la cuidad del Sucursal");
                if (nuevoSucursal.Direccion.Length==0)
                    throw new ArgumentException("Ingrese la direccion del Sucursal");
                if (nuevoSucursal.Telefono == null)
                    throw new ArgumentException("Ingrese el numero telefonico del sucursal");

                DSucursal gestionSucursal = new DSucursal();
                gestionSucursal.Agregar(nuevoSucursal);


            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
    }
}
