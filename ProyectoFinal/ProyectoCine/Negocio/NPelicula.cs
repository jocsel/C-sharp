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

    }
}
