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
    public partial class FrmBuscarPeli : Form
    {
        public string pelicula;
        public int idPelicula;
        public FrmBuscarPeli()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPelicula_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pelicula = dgvPelicula.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                idPelicula = Convert.ToInt32(dgvPelicula.Rows[e.RowIndex].Cells["IdPelicula"].Value.ToString());

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }



        }

        private void FrmBuscarPeli_Load(object sender, EventArgs e)
        {
            try
            {
                NPelicula gestion = new NPelicula();
                List<EPelicula> listapeli = gestion.ObtenerListaPeliculas();
                dgvPelicula.DataSource = listapeli;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
