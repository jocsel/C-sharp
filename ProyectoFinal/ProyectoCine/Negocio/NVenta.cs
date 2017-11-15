using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class NVenta
    {
        public List<EVenta> listVenta()
        {
            try
            {
                DVenta gestionVenta = new DVenta();
                return gestionVenta.ObtenerLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public void agregarVenta(EVenta nuevaVenta)
        {
            if (nuevaVenta.IdCartelera.Id_Cartelera == 0)
                throw new ArgumentException("Ingresa el Id de la cartelera");
            if (nuevaVenta.Fecha == null)
                throw new ArgumentException("Seleccione la fecha de la venta");
            if (nuevaVenta.Hora == null)
                throw new ArgumentException("Selecciona la hora de la venta");
            if (nuevaVenta.NumTicket == 0)
                throw new ArgumentException("Defina la cantidad de boletos a vender");
            if (nuevaVenta.CostoTotal == 0)
                throw new ArgumentException("Defina el monto de la venta");

            DVenta gestionVenta = new DVenta();
            gestionVenta.agregarVenta(nuevaVenta);

        }
        
    }
}
