using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DSucursal
    {
        public List<ESucursal> obtenerSucursal()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "BUSCAR_SUCURSAL";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<ESucursal> listaSucursal = new List<ESucursal>();

                while (leer.Read())
                {
                    ESucursal infoSucursal = new ESucursal();
                    infoSucursal.Id_Sucursal = leer.GetString(0);

                    if (leer.IsDBNull(1))
                        infoSucursal.Nombre = null;
                    else
                        infoSucursal.Nombre = leer.GetString(1);

                    if (leer.IsDBNull(2))
                        infoSucursal.Ciudad = null;
                    else
                        infoSucursal.Ciudad = leer.GetString(2);

                    if (leer.IsDBNull(3))
                        infoSucursal.Telefono = null;
                    else
                        infoSucursal.Telefono = leer.GetInt32(3);
                    if (leer.IsDBNull(4))
                        infoSucursal.Direccion = null;
                    else
                        infoSucursal.Direccion = leer.GetString(4);

                    listaSucursal.Add(infoSucursal);
                }
                return listaSucursal;
            }
               
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
