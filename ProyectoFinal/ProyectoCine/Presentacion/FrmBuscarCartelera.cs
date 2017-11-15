using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmBuscarCartelera : Form
    {

        public string Pelicula;
        public int idcartelera;
        public FrmBuscarCartelera()
        {
            InitializeComponent();



        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        

        private void FrmBuscarCartelera_Load(object sender, EventArgs e)
        {
            try
            {
                NCartelera listacartelera = new NCartelera();
               List<ECartelera> listaCar = listacartelera.listacartelera();

                var lista = (from car in listaCar
                             select new
                             {
                                 car.Id_Cartelera,
                                 Pelicula = car.Id_Pelicula.Nombre,
                                 Sala = car.Id_Sala.nombre,
                                 car.Fecha,
                                 car.Hora,
                                 car.valor,
                                 car.Id_Pelicula.IdPelicula,
                                 car.Id_Sala.IdSala
                             }).ToList();
                dgvBuscarCartelera.DataSource = lista;
                //dgvBuscarCartelera.Columns["IdPelicula"].Visible = false;
              //  dgvBuscarCartelera.Columns["IdSala"].Visible = false;
               // dgvBuscarCartelera.Columns["Id_Cartelera"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

         
        }

        private void dgvBuscarCartelera_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                Pelicula = dgvBuscarCartelera.Rows[e.RowIndex].Cells["Pelicula"].Value.ToString();
                idcartelera = Convert.ToInt32(dgvBuscarCartelera.Rows[e.RowIndex].Cells["Id_Cartelera"].Value.ToString());
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
