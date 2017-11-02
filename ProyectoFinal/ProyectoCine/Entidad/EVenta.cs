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
        public int IdCartelera { get; set; }
        public DateTime Hora { get; set; }
        public int NumTicket { get; set; }
        public double CostoTotal { get; set; }
    }
}
