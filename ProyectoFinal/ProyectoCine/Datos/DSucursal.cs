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
                    infoSucursal.Id_Sucursal = leer.GetInt32(0);

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

        public void Agregar (ESucursal nuevoSucursal)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "INSERTAR_SUC";
                comando.Parameters.AddWithValue("@Nombre",nuevoSucursal.Nombre);
                comando.Parameters.AddWithValue("@Ciudad",nuevoSucursal.Ciudad);
                comando.Parameters.AddWithValue("@Telefono",nuevoSucursal.Telefono);
                comando.Parameters.AddWithValue("@Direccion",nuevoSucursal.Direccion);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public  void Modificar (ESucursal modificarSucursal)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "Actualizar_Suc";
                comando.Parameters.AddWithValue("@Id_sucursal", modificarSucursal.Id_Sucursal);
                comando.Parameters.AddWithValue("@Nombre", modificarSucursal.Nombre);
                comando.Parameters.AddWithValue("@Ciudad", modificarSucursal.Ciudad);
                comando.Parameters.AddWithValue("@Telefono", modificarSucursal.Telefono);
                comando.Parameters.AddWithValue("@Direccion", modificarSucursal.Direccion);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            

        }
        public void Eliminar(ESucursal EliminarSucursal)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ELIMINAR_SUC";
                comando.Parameters.AddWithValue("@Id_Sucursal", EliminarSucursal.Id_Sucursal);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                
                throw ex ;
            }
           
        }
    }
}
