using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DUsuarios
    {
        public List<EUsuario> obtenerListaUsuario()
        {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "BUSCAR_USUARIO";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<EUsuario> listaUsuarios = new List<EUsuario>();

                while (leer.Read())
                {
                    EUsuario datosUsuario = new EUsuario();
                    datosUsuario.Id = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        datosUsuario.Nombre_Usuario = null;
                    else
                        datosUsuario.Nombre_Usuario = leer.GetString(1);

                    if (leer.IsDBNull(2))
                        datosUsuario.Contraseña = null;
                    else
                        datosUsuario.Contraseña = leer.GetString(2);

                    if (leer.IsDBNull(3))
                        datosUsuario.Tipo_De_Usuario = null;
                    else
                        datosUsuario.Tipo_De_Usuario = leer.GetString(3);
                    listaUsuarios.Add(datosUsuario);


                }
                return listaUsuarios;
            }
            catch (Exception ex) {
                throw ex;


            }
        }

        public void Agregar(EUsuario nuevoUsuario)
        {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "INSERTAR_USUARIO";
                comando.Parameters.AddWithValue("@Nombre_Usuario",nuevoUsuario.Nombre_Usuario);
                comando.Parameters.AddWithValue("@Contraseña",nuevoUsuario.Contraseña);
                comando.Parameters.AddWithValue("@Tipo_De_Usuario",nuevoUsuario.Tipo_De_Usuario);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex) {
                throw ex;

            }
        }

        public void Modificar(EUsuario modificarUsuario)
        {
            try {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ACTUALIZAR_USUARIO";
                comando.Parameters.AddWithValue("@Id",modificarUsuario.Id);
                comando.Parameters.AddWithValue("@Nombre_Usuario",modificarUsuario.Nombre_Usuario);
                comando.Parameters.AddWithValue("@Contraseña",modificarUsuario.Contraseña);
                comando.Parameters.AddWithValue("@Tipo_De_Usuario",modificarUsuario.Tipo_De_Usuario);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex) {

                throw ex;
            }

        }

        public void Eliminar(EUsuario eliminarUsuario)
        {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ELIMINAR_USUARIO";
                comando.Parameters.AddWithValue("@Id",eliminarUsuario.Id);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex) {
                throw ex;

            }

        }
    }
}
