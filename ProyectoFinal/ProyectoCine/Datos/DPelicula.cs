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
    public class DPelicula
    {
        public List<EPelicula> ObtenerListaPelicula()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "BUSCAR_PELI";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<EPelicula> listaPelicula = new List<EPelicula>();
                while (leer.Read())
                {
                    EPelicula datosPeli = new EPelicula();
                    datosPeli.Id_Pelicula = leer.GetInt32(0);
                    
                    if (leer.IsDBNull(1))
                        datosPeli.Nombre = null;
                    else
                        datosPeli.Nombre = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        datosPeli.Genero = null;
                    else
                        datosPeli.Genero = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        datosPeli.Idioma = null;
                    else
                        datosPeli.Idioma = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        datosPeli.Subtitulo = null;
                    else
                        datosPeli.Subtitulo = leer.GetString(4);
                    if (leer.IsDBNull(5))
                        datosPeli.Año = null;
                    else
                        datosPeli.Año = leer.GetInt32(5);

                    datosPeli.Duracion = leer.GetTimeSpan(6);
                    listaPelicula.Add(datosPeli);

                }
                return listaPelicula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(EPelicula nuevaPelicula)
        {
            try {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "INSERTAR_PELI";
                comando.Parameters.AddWithValue("@Nombre",nuevaPelicula.Nombre);
                comando.Parameters.AddWithValue("@Genero",nuevaPelicula.Genero);
                comando.Parameters.AddWithValue("@Idioma",nuevaPelicula.Idioma);
                comando.Parameters.AddWithValue("@Subtitulo",nuevaPelicula.Subtitulo);
                comando.Parameters.AddWithValue("@Año",nuevaPelicula.Año);
                comando.Parameters.AddWithValue("@Duracion",nuevaPelicula.Duracion);
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

        public void Modificar(EPelicula modificarPelicula)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ACTUALIZAR_PELI";
                comando.Parameters.AddWithValue("@Id_Pelicula",modificarPelicula.Id_Pelicula);
                comando.Parameters.AddWithValue("@Nombre",modificarPelicula.Nombre);
                comando.Parameters.AddWithValue("@Genero",modificarPelicula.Genero);
                comando.Parameters.AddWithValue("@Idioma",modificarPelicula.Idioma);
                comando.Parameters.AddWithValue("@Subtitulo",modificarPelicula.Subtitulo);
                comando.Parameters.AddWithValue("@Año",modificarPelicula.Año);
                comando.Parameters.AddWithValue("@Duracion",modificarPelicula.Duracion);
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

        public void Eliminar(EPelicula eliminarPelicula)
        {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ELIMINAR_PELI";
                comando.Parameters.AddWithValue("@Id_Pelicula",eliminarPelicula.Id_Pelicula);
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
