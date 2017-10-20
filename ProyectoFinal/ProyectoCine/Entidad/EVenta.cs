using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    class EVenta
    {
        public string IdVenta { get; set; }
        public string IdCartelera { get; set; }
        public DateTime Hora { get; set; }
        public int NumTicket { get; set; }
        public double CostoTotal { get; set; }
 
    }
}
