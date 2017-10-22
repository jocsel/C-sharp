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
    }
}
