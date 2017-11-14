using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
   public   class ECartelera
    {
        public int Id_Cartelera { get; set; }
        public EPelicula Id_Pelicula { get; set; }
        public ESala Id_Sala { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public decimal? valor { get; set; }

       public ECartelera()
        {
            Id_Pelicula = new EPelicula();
            Id_Sala = new ESala();
        }
    }
}
