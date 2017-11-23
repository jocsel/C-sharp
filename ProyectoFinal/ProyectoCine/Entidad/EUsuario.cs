using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EUsuario
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }

        public EPermiso Permiso { get; set; }

        public EUsuario()
        {
            Permiso = new EPermiso();
        }
    }
}
