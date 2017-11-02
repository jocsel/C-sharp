using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public class NPelicula
    {
        public List<EPelicula> ObtenerListaPeliculas()
        {
            try
            {
                DPelicula datosPelicula = new DPelicula();
                return datosPelicula.ObtenerListaPelicula();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(EPelicula agregarPelicula) {

            try {
                if (agregarPelicula.Nombre.Length == 0)
                    throw new ArgumentException("Ingresa el nombre de la pelicula");
                if (agregarPelicula.Genero.Length == 0)
                    throw new ArgumentException("Ingresa el genero de la pelicula");
                if (agregarPelicula.Idioma.Length == 0)
                    throw new ArgumentException("Ingresa el idioma de la pelicula");
                if (agregarPelicula.Subtitulo.Length == 0)
                    throw new ArgumentException("Ingresa el subtitulo de la pelicula");
                if (agregarPelicula.Año == null)
                    throw new ArgumentException("Ingresa el año de la pelicula");
                if (agregarPelicula.Duracion == null)
                    throw new ArgumentException("Ingrese el tiempo de duracion de la peicula");
                DPelicula gestionPelicula = new DPelicula();
                gestionPelicula.Agregar(agregarPelicula);

            }
            catch (Exception ex) {

                throw ex;
            }
        }
        public void Modificar(EPelicula modificarPelicula)
        {
            try {
                if (modificarPelicula.Nombre.Length == 0)
                    throw new ArgumentException("Ingresa el nombre de la pelicula");
                if (modificarPelicula.Genero.Length == 0)
                    throw new ArgumentException("Ingresa el genero de la pelicula");
                if (modificarPelicula.Idioma.Length == 0)
                    throw new ArgumentException("Ingresa el idioma de la pelicula");
                if (modificarPelicula.Subtitulo.Length == 0)
                    throw new ArgumentException("Ingresa el subtitulo de la pelicula");
                if (modificarPelicula.Año == null)
                    throw new ArgumentException("Ingresa el año de la pelicula");
                if (modificarPelicula.Duracion == null)
                    throw new ArgumentException("Ingresa la duracion de la peicula");
                DPelicula gestionPelicula = new DPelicula();
                gestionPelicula.Modificar(modificarPelicula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(EPelicula eliminarPelicula) {

            try {

                DPelicula eliminar = new DPelicula();
                eliminar.Eliminar(eliminarPelicula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
