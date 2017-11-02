using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    class ECartelera
    {
        public int Id_Cartelera { get; set; }
        public int Id_Pelicula { get; set; }
        public int Id_Sala { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public double valor { get; set; }
    }
}
