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
    public partial class FrmSucursal : Form
    {
        List<ESucursal> listaSucursales;
        public FrmSucursal()
        {
            InitializeComponent();
        }

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                actualizaSucursal();
                dgvSucursal.DataSource = listaSucursales;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void actualizaSucursal()
        {
            NSucursal gestionSucursal = new NSucursal();
            listaSucursales = gestionSucursal.obtenerSucursal();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
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
            txtcuidad.Enabled = true;
            txttelefono.Enabled = true;
            txtdireccion.Enabled = true;


        }
        private void Deshabilitar()
        {
            txtnombre.Enabled = false;
            txtcuidad.Enabled = false;
            txttelefono.Enabled = false;
            txtdireccion.Enabled = false;

        }
        private void Limpiar()
        {
            txtnombre.Text = "";
            txtcuidad.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            try
            {
                ESucursal newSucursal = new ESucursal();
                newSucursal.Nombre = txtnombre.Text;
                newSucursal.Ciudad = txtcuidad.Text;
                newSucursal.Direccion = txtdireccion.Text;
                newSucursal.Telefono = Convert.ToInt32(txttelefono.Text);
                NSucursal gestion = new NSucursal();
                gestion.Agregar(newSucursal);
                MessageBox.Show("Se guardo correctamente", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizaSucursal();
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
    }
}
