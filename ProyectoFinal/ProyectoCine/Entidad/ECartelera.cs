using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    class ECartelera
    {
        public string  Id_Cartelera { get; set; }
        public string Id_Pelicula { get; set; }
        public string Id_Sala { get; set; }
        public  DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public double valor { get; set; }
    }
}
