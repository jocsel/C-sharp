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
                                     + " Sala, Pelicula, Cartelera, Venta, usuarios, Permiso.Password  \n" +
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
                    resultadoUsuario.Permiso.Sala = leer.GetBoolean(4); //SE BLOQUE JUNTO CON PELICULA
                    
                }
                return resultadoUsuario;
            }
            catch (Exception ex) {

                throw ex;
            }
        }



        public List<EUsuario> ObtenerLista()
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select Usuarios.Usuario, Usuarios.Password, Usuarios.Nombre, Usuarios.Apellido, Sucursal \n"
                                 + " Sala, Pelicula, Cartelera, Venta, usuarios, Permiso.Password  \n" +
                                 " from Usuarios  \n"
                                 + " inner join Permiso on Usuarios.Usuario = Permiso.Usuario " +
                                  " where Usuarios.Usuario = @Usuario and Usuarios.Password = @Password";

            comando.Connection = conexion;
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();
            List<ECartelera> listaCartelera = new List<ECartelera>();

            while (leer.Read())
            {
                EUsuario usuario = new EUsuario();

                if (leer.IsDBNull(3))
                    usuario.Usuario = null;
                else
                    usuario.Usuario = leer.GetString();

                if (leer.IsDBNull(4))
                    usuario.Nombres = null;
                else
                    usuario.Nombres = leer.GetString(4);

                if (leer.IsDBNull(5))
                    newcar.valor = null;
                else
                    newcar.valor = leer.GetDecimal(5);

                if (leer.IsDBNull(6))
                    newcar.Id_Pelicula.Nombre = null;
                else
                    newcar.Id_Pelicula.Nombre = leer.GetString(6);

                if (leer.IsDBNull(7))
                    newcar.Id_Pelicula.Genero = null;
                else
                    newcar.Id_Pelicula.Genero = leer.GetString(7);
            }

            }
    }
}
