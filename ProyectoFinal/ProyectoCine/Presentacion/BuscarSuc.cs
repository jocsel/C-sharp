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
    public partial class BuscarSuc : Form
    {
        public string sucursal;
        public int idSucurssal;
        public BuscarSuc()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sucursal = dgvBusarsala.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                idSucurssal = Convert.ToInt32(dgvBusarsala.Rows[e.RowIndex].Cells["Id_Sucursal"].Value.ToString());

                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            
        }

        private void BuscarSala_Load(object sender, EventArgs e)
        {
            try
            {
                NSucursal gestion = new NSucursal();
               List<ESucursal> listasala = gestion.obtenerSucursal();           
                dgvBusarsala.DataSource = listasala;

            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.Message, "Error");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
    }
}
