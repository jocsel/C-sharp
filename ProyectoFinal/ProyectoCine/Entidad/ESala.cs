using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
     public class ESala
    {
        public int? IdSala { get; set; }
        public ESucursal IdSucursal { get; set; }
        public string nombre { get; set; }

        public int? Capacidad { get; set; }

         public ESala()
         {
             IdSucursal = new ESucursal();
     }
    }
}
