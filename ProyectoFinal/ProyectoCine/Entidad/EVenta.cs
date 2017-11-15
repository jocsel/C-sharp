using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EVenta
    {
        public int IdVenta { get; set; }
        public ECartelera IdCartelera { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int? NumTicket { get; set; }
        public decimal? CostoTotal { get; set; }
       

        public EVenta() {

            IdCartelera = new ECartelera();
            

        }
    }
}
