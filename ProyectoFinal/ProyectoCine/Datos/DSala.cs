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

                 if(read.IsDBNull(1))
                    infoSalas.IdSucursal =null;
                 else
                    infoSalas.IdSucursal=read.GetInt32(1);

                if(read.IsDBNull(2))
                    infoSalas.Capacidad=null;
                else
                    infoSalas.Capacidad=read.GetInt32(2);

                    listasala.Add(infoSalas);
                }     
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
            comando.Parameters.AddWithValue("@Id_Sucursal",nuevosala.IdSucursal);
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
                comando.Parameters.AddWithValue("@Id_Sucursal", modsala.IdSucursal);
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
