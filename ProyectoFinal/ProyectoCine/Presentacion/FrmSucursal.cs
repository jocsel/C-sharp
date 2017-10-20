using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;


namespace Presentacion
{
    public partial class FrmSucursal : Form
    {
        public FrmSucursal()
        {
            InitializeComponent();
        }
        DSucursal sucursal = new DSucursal();
        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            dgvSucursal.DataSource = sucursal.mostrarSucursales();
        }
    }
}
