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
    public class DLogin
    {

        public Entidad.EUsuario Login(string usuario, string password)
        {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select Usuarios.Usuario, Usuarios.Password, Usuarios.Nombre, Usuarios.Apellido, Sucursal \n"
                                     + " Sala, Pelicula, Cartelera, Venta, usuarios,Salir, Permiso.Password  \n" +
                                     " from Usuarios  \n"
                                     + " inner join Permiso on Usuarios.Usuario = Permiso.Usuario " +
                                      " where Usuarios.Usuario = @Usuario and Usuarios.Password = @Password";
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Password", password);
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                EUsuario resultadoUsuario = new EUsuario();
                while (leer.Read()) {
                    resultadoUsuario.Usuario = leer.GetString(0);
                    resultadoUsuario.Nombres = leer.GetString(2);
                    resultadoUsuario.Apellido = leer.GetString(3);
                    resultadoUsuario.Permiso.Sucursal = leer.GetBoolean(4);
                    resultadoUsuario.Permiso.Pelicula = leer.GetBoolean(5);
                    resultadoUsuario.Permiso.Cartelera = leer.GetBoolean(6); 
                    resultadoUsuario.Permiso.Venta = leer.GetBoolean(7); 
                    resultadoUsuario.Permiso.User = leer.GetBoolean(8); 
                    resultadoUsuario.Permiso.Salir = leer.GetBoolean(9); 
                    resultadoUsuario.Permiso.Sala = leer.GetBoolean(5); //SE BLOQUE JUNTO CON PELICULA
                    
                }
                return resultadoUsuario;
            }
            catch (Exception ex) {

                throw ex;
            }
        }
    }
}
