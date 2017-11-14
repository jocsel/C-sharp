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
    public partial class FrmBuscarSala : Form
    {
        public string sala;
        public int idsala;
        public FrmBuscarSala()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBuscarSala_Load(object sender, EventArgs e)
        {
            try
            {
                NSala gestion = new NSala();
                List<ESala> listasala = gestion.obtenerSala();


                var lista = (from sala in listasala
                             select new
                             {
                                 sala.IdSala,
                                 Nombre = sala.nombre,
                                 Sucursal = sala.IdSucursal.Nombre,
                                 sala.Capacidad,
                                 sala.IdSucursal.Id_Sucursal
                             }).ToList();
                dgvSala.DataSource = lista;
                dgvSala.Columns["Id_Sucursal"].Visible = false;
                dgvSala.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void dgvSala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sala = dgvSala.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                idsala = Convert.ToInt32(dgvSala.Rows[e.RowIndex].Cells["IdSala"].Value.ToString());

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                
            }



        }
    }
}
