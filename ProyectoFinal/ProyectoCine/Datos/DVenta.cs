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
   public class DVenta
    {
        public List<EVenta> ObtenerLista() {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "BUSCAR_VENTAS";
                comando.Connection = conexion;
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();
                List<EVenta> listaVenta = new List<EVenta>();
                while (leer.Read()) {
                    EVenta listaventa = new EVenta();
                    listaventa.IdVenta = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        listaventa.IdCartelera = null;
                    else
                        listaventa.IdCartelera.Id_Cartelera = leer.GetInt32(1);
                    if (leer.IsDBNull(2))
                        listaventa.IdCartelera.Id_Pelicula.Nombre = null;
                    else
                        listaventa.IdCartelera.Id_Pelicula.Nombre = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        listaventa.IdCartelera.Id_Sala.nombre = null;
                    else
                        listaventa.IdCartelera.Id_Sala.nombre = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        listaventa.Fecha = null;
                    else
                        listaventa.Fecha = leer.GetDateTime(4);
                    if (leer.IsDBNull(5))
                        listaventa.Hora = null;
                    else
                        listaventa.Hora = leer.GetTimeSpan(5);
                    if (leer.IsDBNull(6))
                        listaventa.NumTicket = null;
                    else
                        listaventa.NumTicket = leer.GetInt32(6);

                    if (leer.IsDBNull(7))
                        listaventa.IdCartelera.valor = null;
                    else
                        listaventa.IdCartelera.valor = leer.GetDecimal(7);

                    if (leer.IsDBNull(8))
                        listaventa.CostoTotal = null;
                    else
                        listaventa.CostoTotal = leer.GetDecimal(8);
                        listaVenta.Add(listaventa);
                }
                conexion.Close();
                leer.Close();
                return listaVenta;
            }
            catch (Exception ex) {

                throw ex;
            }

        }
        
        public void agregarVenta(EVenta nuevaVenta) {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "INSERTAR_VENTAS";
                comando.Parameters.AddWithValue("@Id_Cartelera",nuevaVenta.IdCartelera.Id_Cartelera);
                comando.Parameters.AddWithValue("@Fecha",nuevaVenta.Fecha);
                comando.Parameters.AddWithValue("@Hora",nuevaVenta.Hora);
                comando.Parameters.AddWithValue("@Num_ticket",nuevaVenta.NumTicket);
                comando.Parameters.AddWithValue("@Costo_total",nuevaVenta.CostoTotal);
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
