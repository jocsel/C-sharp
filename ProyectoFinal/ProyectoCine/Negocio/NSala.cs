using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;


namespace Negocio
{
    public class NSala
    {
        public List<ESala> obtenerSala()
    {
        try 
	{
        DSala datossala = new DSala();
        return datossala.ObtenerSala();
        
		
	}
	catch (Exception ex)
	{
		
		throw ex;
	}
    }

        public void agregarsala(ESala nuevoSala)
        {
            try
            {
                if (nuevoSala.IdSucursal.Id_Sucursal == 0)
                    throw new ArgumentException("Ingrese el sucursal");
                if (nuevoSala.nombre.Length == 0)
                    throw new ArgumentException("Ingrse el nombre de la sala");
                if (nuevoSala.Capacidad.Value == 0 || nuevoSala.Capacidad.Value < 0)
                    throw new ArgumentException("Ingrese una cantidad valida");

                DSala datossala = new DSala();
                datossala.agregar(nuevoSala);
             
            }
            catch (Exception ex)
            {
                
                throw ex;
            }


        }
        public void modificar(ESala modsala)
        {
            try
            {
                if (modsala.IdSucursal.Nombre.Length == 0)
                    throw new ArgumentException("Ingrese un sucursal");
                if (modsala.nombre.Length == 0)
                    throw new ArgumentException("Ingrse el nombre de la sala");
                if (modsala.Capacidad.Value == 0 | modsala.Capacidad.Value < 0)
                    throw new ArgumentException("ingrese una cantidad valida");

                DSala datossala = new DSala();
                datossala.modificar(modsala);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void eliminar (ESala eliminarsala)
        {
            try
            {
                DSala datoseliminar = new DSala();
                datoseliminar.eliminar(eliminarsala);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
