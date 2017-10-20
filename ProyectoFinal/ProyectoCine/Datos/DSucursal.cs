using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DSucursal
    {
        SqlConnection conexionSucursal = new SqlConnection(Properties.Settings.Default.CadenaConexion);

        public DataTable mostrarSucursales()
        {
            SqlDataAdapter da = new SqlDataAdapter("BUSCAR_SUCURSAL",conexionSucursal.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
