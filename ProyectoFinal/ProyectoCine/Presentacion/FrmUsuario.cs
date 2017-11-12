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
    public partial class FrmUsuario : Form
    {

        List<EUsuario> listaUsuarios;
        bool modificar;
        public FrmUsuario()
        {
            InitializeComponent();
            Deshabilitar();
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            btnguardar.Enabled = false;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuario.AutoResizeColumns();
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            try {
                actualizarListaUsuarios();
                dgvUsuario.DataSource = listaUsuarios;
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void actualizarListaUsuarios()
        {
            NUsuario gestionUsuario = new NUsuario();
            listaUsuarios = gestionUsuario.obtenerListaUsuarios();
        }

        private void Filtrar()
        {
            var busqueda = (
                from Usuarios in listaUsuarios
                where Usuarios.Nombre_Usuario.ToUpper().StartsWith(txtFiltrarUsuario.Text.ToUpper())
                select Usuarios).ToList();
            dgvUsuario.DataSource = busqueda;
        }

        private void txtFiltrarUsuario_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btncancelar.Enabled = true;
            btneliminar.Enabled = false;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            
        }
        private void Habilitar()
        {
            txtnombreapellido.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtxContraseña.Enabled = true;
            cbTipoUsuario.Enabled = true;
        }

        private void Deshabilitar()
        {
            txtNombreUsuario.Enabled = false;
            txtnombreapellido.Enabled = false;
            txtxContraseña.Enabled = false;
            cbTipoUsuario.Enabled = false;
           
        }
        private void Limpiar()
        {
            txtNombreUsuario.Text = "";
            txtnombreapellido.Text = "";
            txtxContraseña.Text = "";
            cbTipoUsuario.Text = "";

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btneliminar.Enabled = false;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Seguro que quieres eliminar este registro", "Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EUsuario borrar = new EUsuario();
                    borrar.Id = Convert.ToInt32(txtNombreUsuario.Tag);

                    NUsuario gestionUsua = new NUsuario();
                    gestionUsua.Eliminar(borrar);
                    Limpiar();
                    actualizarListaUsuarios();
                    dgvUsuario.DataSource = listaUsuarios;
                }

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try {

                if (modificar)
                {
                    EUsuario modUsuario = new EUsuario();
                    modUsuario.Id = Convert.ToInt32(txtNombreUsuario.Tag.ToString());
                    modUsuario.Nombre = txtnombreapellido.Text;
                    modUsuario.Nombre_Usuario = txtNombreUsuario.Text;
                    modUsuario.Contraseña = txtxContraseña.Text;
                    modUsuario.Tipo_De_Usuario = cbTipoUsuario.Text;

                    NUsuario gestionUser = new NUsuario();
                    gestionUser.Modificar(modUsuario);
                    MessageBox.Show("Cambios realizados correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {

                    EUsuario nuevoUsuario = new EUsuario();
                    nuevoUsuario.Nombre = txtnombreapellido.Text;
                    nuevoUsuario.Nombre_Usuario = txtNombreUsuario.Text;
                    nuevoUsuario.Contraseña = txtxContraseña.Text;
                    nuevoUsuario.Tipo_De_Usuario = cbTipoUsuario.Text;

                    NUsuario gestionUsuarios = new NUsuario();
                    gestionUsuarios.Agregar(nuevoUsuario);
                    MessageBox.Show("Se guardo correctamente","Usuario",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }

                actualizarListaUsuarios();
                dgvUsuario.DataSource = listaUsuarios;
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btneliminar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                txtNombreUsuario.Tag = Convert.ToInt32(dgvUsuario.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                if (dgvUsuario.Rows[e.RowIndex].Cells["Nombre"].Value == null)
                    txtnombreapellido.Text = "";
                else
                    txtnombreapellido.Text = dgvUsuario.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                if (dgvUsuario.Rows[e.RowIndex].Cells["Nombre_Usuario"].Value == null)
                    txtNombreUsuario.Text = "";
                else
                    txtNombreUsuario.Text = dgvUsuario.Rows[e.RowIndex].Cells["Nombre_Usuario"].Value.ToString();

                if (dgvUsuario.Rows[e.RowIndex].Cells["Contraseña"].Value == null)
                    txtxContraseña.Text = "";
                else
                    txtxContraseña.Text = dgvUsuario.Rows[e.RowIndex].Cells["Contraseña"].Value.ToString();
                if (dgvUsuario.Rows[e.RowIndex].Cells["Tipo_De_Usuario"].Value == null)
                    cbTipoUsuario.Text = "";
                else
                    cbTipoUsuario.Text = dgvUsuario.Rows[e.RowIndex].Cells["Tipo_De_Usuario"].Value.ToString();

                btneliminar.Enabled = true;
                btnmodificar.Enabled = true;
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                Deshabilitar();


            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btnguardar.Enabled = false;
            btnnuevo.Enabled = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
            this.Close();
        }
    }
}
