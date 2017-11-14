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
    public class DSala
    {
        public List<ESala> ObtenerSala()
        {
            try
            {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "BUSCAR_SALA";
            comando.Connection = conexion;
            conexion.Open();


            SqlDataReader read = comando.ExecuteReader();
            List<ESala> listasala = new List<ESala>();

                 while (read.Read())
                 {            	            	 
                ESala infoSalas = new ESala();
               
                infoSalas.IdSala = read.GetInt32(0);
              
                 infoSalas.IdSucursal.Id_Sucursal = read.GetInt32(1);

                 if (read.IsDBNull(2))
                     infoSalas.nombre = null;
                 else
                     infoSalas.nombre = read.GetString(2);
                 if (read.IsDBNull(3))
                     infoSalas.Capacidad = null;
                 else
                     infoSalas.Capacidad = read.GetInt32(3);

                 if(read.IsDBNull(4))
                    infoSalas.IdSucursal.Nombre =null;
                 else
                    infoSalas.IdSucursal.Nombre=read.GetString(4);

                 if (read.IsDBNull(5))
                     infoSalas.IdSucursal.Ciudad = null;
                 else
                     infoSalas.IdSucursal.Ciudad = read.GetString(5);
                 if (read.IsDBNull(6))
                     infoSalas.IdSucursal.Telefono = null;
                 else
                     infoSalas.IdSucursal.Telefono = read.GetInt32(6);
                 if (read.IsDBNull(7))
                     infoSalas.IdSucursal.Direccion = null;
                 else
                     infoSalas.IdSucursal.Direccion = read.GetString(7);

                

                    listasala.Add(infoSalas);
                }
                 conexion.Close();
                 read.Close();
                return listasala;
            }
           catch (Exception ex)
            {
               throw ex;
           }
            

            }


        public void agregar(ESala nuevosala)
        {
            try{
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandType=CommandType.StoredProcedure;
            comando.CommandText="INSERTAR_SALA";
            comando.Parameters.AddWithValue("@nombre", nuevosala.nombre);
            comando.Parameters.AddWithValue("@Id_Sucursal",nuevosala.IdSucursal.Id_Sucursal);
            comando.Parameters.AddWithValue("@Capacidad",nuevosala.Capacidad);
            comando.Connection= conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(ESala modsala)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ACTUALIZAR_SALA";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@Id_Sala", modsala.IdSala);
                comando.Parameters.AddWithValue("@nombre", modsala.nombre);
                comando.Parameters.AddWithValue("@Id_Sucursal", modsala.IdSucursal.Id_Sucursal);
                comando.Parameters.AddWithValue("@Capacidad", modsala.Capacidad);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void eliminar (ESala eliminarsala)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ELIMINAR_SALA";
                comando.Parameters.AddWithValue("@Id_sala", eliminarsala.IdSala);
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
    }
}
