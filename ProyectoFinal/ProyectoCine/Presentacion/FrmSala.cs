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
   
    public partial class FrmSala : Form
    {
        List<ESala> listasala;
        bool modificar;
        
       
        public FrmSala()
        {
            InitializeComponent();
            deshabilitar();
            btnsucursal.Enabled = false;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            btnguardar.Enabled = false;

        }

        private void FrmSala_Load(object sender, EventArgs e)
        {
            try
            {
                actualizartabla();
                
              
            }
            catch (Exception ex)
            {

                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            

        }

        private void actualizartabla()
        {

            NSala getionardatos = new NSala();
            listasala =  getionardatos.obtenerSala();

            var lista = (from sala in listasala
                         select new
                             {
                                 sala.IdSala,
                                 Nombre=sala.nombre,
                                 Sucursal = sala.IdSucursal.Nombre,
                                 sala.Capacidad,
                                 sala.IdSucursal.Id_Sucursal                                
                             }).ToList();
            dgvSala.DataSource = lista;
            dgvSala.Columns["Id_Sucursal"].Visible = false;

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            cbsucursal.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnsucursal.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btnnuevo.Enabled = false;
            cbsucursal.Enabled = false;


        }
        public void habilitar()
        {
            cbsucursal.Enabled = true;
            txtcapacidad.Enabled = true;
            txtnombre.Enabled = true;
        }

        public void deshabilitar()
        {
            cbsucursal.Enabled = false;
            txtcapacidad.Enabled = false;
            txtnombre.Enabled = false;

        }
        public void limpiar()
        {
            cbsucursal.Text = "";
            txtcapacidad.Text = "";
            txtnombre.Text = "";

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(modificar)
                {
                    ESala modsala = new ESala();

                    modsala.IdSala =Convert.ToInt32(txtnombre.Tag.ToString());
                    modsala.nombre = txtnombre.Text;
                    modsala.IdSucursal.Id_Sucursal = Convert.ToInt32(cbsucursal.Tag);
                    modsala.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                    modsala.IdSucursal.Nombre = cbsucursal.Text;
                    NSala gestionsala = new NSala();
                    gestionsala.modificar(modsala);
                    MessageBox.Show("Se modifico correctamente", "Sala", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ESala newsala = new ESala();
                    newsala.IdSucursal.Id_Sucursal = Convert.ToInt32(cbsucursal.Tag);
                    newsala.nombre = txtnombre.Text;
                    newsala.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                    newsala.IdSucursal.Nombre = cbsucursal.Text;              
                    NSala datossala = new NSala();
                    datossala.agregarsala(newsala);
                    MessageBox.Show("Se guardo correctamente", "Sala", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                actualizartabla();
                //dgvSala.DataSource = listasala;
                limpiar();
                deshabilitar();
                btncancelar.Enabled = false;
                btneliminar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                btnsucursal.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seguro que deseas eliminar este registro","Sala",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    ESala eliminar = new ESala();
                    eliminar.IdSala = Convert.ToInt32(txtnombre.Tag);
                    NSala datoseliminar = new NSala();
                    datoseliminar.eliminar(eliminar);
                    limpiar();
                    actualizartabla();
                    //dgvSala.DataSource = listasala;

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void dgvSala_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                txtnombre.Tag = Convert.ToInt32(dgvSala.Rows[e.RowIndex].Cells["IdSala"].Value.ToString());
                txtnombre.Text = dgvSala.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                cbsucursal.Text = dgvSala.Rows[e.RowIndex].Cells["Sucursal"].Value.ToString();
                cbsucursal.Tag = dgvSala.Rows[e.RowIndex].Cells["Id_Sucursal"].Value.ToString();
                txtcapacidad.Text = dgvSala.Rows[e.RowIndex].Cells["Capacidad"].Value.ToString();
                btnmodificar.Enabled = true;
                btneliminar.Enabled = true;
                
                deshabilitar();


            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btneliminar.Enabled = false;
            btnmodificar.Enabled = false;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnsucursal.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            btneliminar.Enabled = false;
            modificar = true;
            cbsucursal.Enabled = false;

            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnsucursal_Click(object sender, EventArgs e)
        {
            BuscarSuc newsucursal = new BuscarSuc();

            if (newsucursal.ShowDialog() == DialogResult.OK)
            {
                cbsucursal.Text = newsucursal.sucursal.ToString();
                cbsucursal.Tag = newsucursal.idSucurssal.ToString();
            }

        }
        

    }

}
