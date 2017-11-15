using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
   public class NCartelera
    {
        public List<ECartelera> listacartelera()
        {
        Dcartelera getionardatos = new Dcartelera();
        return getionardatos.ObtenerLista();
        }

       public void agregarCartelera(ECartelera NewCartelera)
       {
           if (NewCartelera.Id_Pelicula.IdPelicula == 0)
               throw new ArgumentException("Ingrese una Pelicula");
           if (NewCartelera.Id_Sala.IdSala == 0)
               throw new ArgumentException("Ingrese una Sala");
           if (NewCartelera.Fecha.Value == null)
               throw new ArgumentException("Ingrese la Fecha de la pelicula ");
           if (NewCartelera.Hora.Value == null)
               throw new ArgumentException("Ingrese una Fecha correcta");
           if (NewCartelera.valor.Value == 0)
               throw new ArgumentException("Ingrese un Valor de la Cartelera");

           Dcartelera gestionCar = new Dcartelera();
           gestionCar.AgregarCartelera(NewCartelera);

       }

        public void Modificar(ECartelera modificarCartelera)
        {

            try {
                if (modificarCartelera.Id_Pelicula.IdPelicula == 0)
                    throw new ArgumentException("Ingrese una Pelicula");
                if (modificarCartelera.Id_Sala.IdSala == 0)
                    throw new ArgumentException("Ingrese una Sa&la");
                if (modificarCartelera.Fecha == null)
                    throw new ArgumentException("Ingrese la fecha");
                if (modificarCartelera.Hora == null)
                    throw new ArgumentException("Ingrese la hora ");
                if (modificarCartelera.valor == 0)
                    throw new ArgumentException("Ingrese el valor de la cartelera");
                
                    

                Dcartelera getion = new Dcartelera();
                getion.Modificar(modificarCartelera);

            }
            catch (Exception ex) {

                throw ex;
            }
        }
        public void eliminracarte(ECartelera eliminarcar)
        {
            try
            {
                Dcartelera eliminar = new Dcartelera ();
                eliminar.eliminarcartelera(eliminarcar);

                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

