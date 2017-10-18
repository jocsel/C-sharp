using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EPelicula
    {
        public string Id_Pelicula { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Idioma { get; set; }
        public string Subtitulo { get; set; }
        public int Año { get; set; }
        public TimeSpan Duracion {get; set; }
    }
}
