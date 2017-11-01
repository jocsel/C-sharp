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
using Datos;

namespace Presentacion
{
    public partial class FrmSucursal : Form
    {
        List<ESucursal> listaSucursales;
        bool modificar;
        public FrmSucursal()
        {
            InitializeComponent();
            Deshabilitar();
        }
        
        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            DSucursal sucursal = new DSucursal();
            dgvSucursal.DataSource = sucursal.obtenerSucursal();
            dgvSucursal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSucursal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            try
            {
                actualizarSucursal();
                dgvSucursal.DataSource = listaSucursales;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void actualizarSucursal()
        {
            NSucursal gestionSucursal = new NSucursal();
            listaSucursales = gestionSucursal.obtenerSucursal();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            txtnombre.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btnnuevo.Enabled = false;

        }

        private void Habilitar()
        {
            txtnombre.Enabled = true;
            txtciudad.Enabled = true;
            txttelefono.Enabled = true;
            txtdireccion.Enabled = true;


        }
        private void Deshabilitar()
        {
            txtnombre.Enabled = false;
            txtciudad.Enabled = false;
            txttelefono.Enabled = false;
            txtdireccion.Enabled = false;

        }
        private void Limpiar()
        {
            txtnombre.Text = "";
            txtciudad.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            try
            {

                if (modificar)
                {
                    ESucursal ModSucursal = new ESucursal();
                    ModSucursal.Id_Sucursal=Convert.ToInt32(txtnombre.Tag.ToString());
                    ModSucursal.Nombre = txtnombre.Text;
                    ModSucursal.Ciudad = txtciudad.Text;
                    ModSucursal.Telefono = Convert.ToInt32(txttelefono.Text);
                    ModSucursal.Direccion = txtdireccion.Text;

                    NSucursal gestionsuc = new NSucursal();
                    gestionsuc.Modificar(ModSucursal);

                    MessageBox.Show("Se modifico correctamente", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                ESucursal newSucursal = new ESucursal();
                newSucursal.Nombre = txtnombre.Text;
                newSucursal.Ciudad = txtciudad.Text;
                newSucursal.Direccion = txtdireccion.Text;
                newSucursal.Telefono = Convert.ToInt32(txttelefono.Text);

                NSucursal gestion = new NSucursal();
                gestion.Agregar(newSucursal);
                MessageBox.Show("Se guardo correctamente", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                actualizarSucursal();
                dgvSucursal.DataSource = listaSucursales;
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btneliminar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
               
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
            }



        }

        public void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            btneliminar.Enabled = false;
            modificar = true;
           
        }

        private void dgvSucursal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                //falta la validacion de datos nulos
                txtnombre.Tag =Convert.ToInt32(dgvSucursal.Rows[e.RowIndex].Cells["Id_Sucursal"].Value.ToString());
                txtnombre.Text = dgvSucursal.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtciudad.Text = dgvSucursal.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
                txttelefono.Text = dgvSucursal.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtdireccion.Text = dgvSucursal.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                btnmodificar.Enabled = true;
                btneliminar.Enabled = true;
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Seguro que deseas eliminar este registro","Sucursal",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    ESucursal eliminar = new ESucursal();
                    eliminar.Id_Sucursal =Convert.ToInt32( txtnombre.Tag);
                    NSucursal gestionsuc = new NSucursal();
                    gestionsuc.ELiminar(eliminar);
                    Limpiar();
                    actualizarSucursal();
                    dgvSucursal.DataSource = listaSucursales;
                }

            }
            catch (Exception ex)

            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btneliminar.Enabled = false;
            btnmodificar.Enabled = false;
           
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
