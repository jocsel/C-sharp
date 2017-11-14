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
    public class Dcartelera
    {
        public List<ECartelera> ObtenerLista()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "BUSCAR_CARTELERA";
                comando.Connection = conexion;
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();
                List<ECartelera> listaCartelera = new List<ECartelera>();

                while (leer.Read())
                {
                    ECartelera newcar = new ECartelera();

                    newcar.Id_Cartelera = leer.GetInt32(0);
                    newcar.Id_Pelicula.IdPelicula = leer.GetInt32(1);
                    newcar.Id_Sala.IdSala = leer.GetInt32(2);

                    if (leer.IsDBNull(3))
                        newcar.Fecha = null;
                    else
                        newcar.Fecha = leer.GetDateTime(3);

                    if (leer.IsDBNull(4))
                        newcar.Hora = null;
                    else
                        newcar.Hora = leer.GetTimeSpan(4);

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

                    if (leer.IsDBNull(8))
                        newcar.Id_Pelicula.Idioma = null;
                    else
                        newcar.Id_Pelicula.Idioma = leer.GetString(8);

                    if (leer.IsDBNull(9))
                        newcar.Id_Pelicula.Subtitulo = null;
                    else
                        newcar.Id_Pelicula.Subtitulo = leer.GetString(9);

                    if (leer.IsDBNull(10))
                        newcar.Id_Pelicula.Año = null;
                    else
                        newcar.Id_Pelicula.Año = leer.GetInt32(10);

                    if (leer.IsDBNull(11))
                        newcar.Id_Pelicula.Duracion = null;
                    else
                        newcar.Id_Pelicula.Duracion = leer.GetTimeSpan(11);

                    if (leer.IsDBNull(12))
                        newcar.Id_Sala.nombre = null;
                    else
                        newcar.Id_Sala.nombre = leer.GetString(12);
                    if (leer.IsDBNull(13))
                        newcar.Id_Sala.Capacidad = null;
                    else
                        newcar.Id_Sala.Capacidad = leer.GetInt32(13);


                    listaCartelera.Add(newcar);

                }
                conexion.Close();
                leer.Close();
                return listaCartelera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarCartelera(ECartelera Newcartelera)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "INSERTAR_CARTELERA";
                comando.Parameters.AddWithValue("@Id_Pelicula", Newcartelera.Id_Pelicula.IdPelicula);
                comando.Parameters.AddWithValue("@Id_Sala", Newcartelera.Id_Sala.IdSala);
                comando.Parameters.AddWithValue("@Fecha", Newcartelera.Fecha);
                comando.Parameters.AddWithValue("@Hora", Newcartelera.Hora);
                comando.Parameters.AddWithValue("@valor", Newcartelera.valor);
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

        public void Modificar(ECartelera modificarCartelera)
        {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ACTUALIZAR_CARTELERA";
                comando.Parameters.AddWithValue("@Id_Cartelera", modificarCartelera.Id_Cartelera);
                comando.Parameters.AddWithValue("@Id_Pelicula", modificarCartelera.Id_Pelicula.IdPelicula);
                comando.Parameters.AddWithValue("@Id_Sala", modificarCartelera.Id_Sala.IdSala);
                comando.Parameters.AddWithValue("@Fecha", modificarCartelera.Fecha);
                comando.Parameters.AddWithValue("@Hora", modificarCartelera.Hora);
                comando.Parameters.AddWithValue("@valor", modificarCartelera.valor);
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
        public void eliminarcartelera(ECartelera eliminarcarte)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ELIMINAR_CARTELERA";
                comando.Parameters.AddWithValue("@Id_Cartelera", eliminarcarte.Id_Cartelera);
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

