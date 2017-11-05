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
    public partial class FrmPelicula : Form
    {
        List<EPelicula> listaPeliculas;
        bool modificar;
        public FrmPelicula()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            dgvPeliculas.AutoResizeColumns();
            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPeliculas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
           
            try
            {
                actualizarListaPelicula();
                dgvPeliculas.DataSource = listaPeliculas;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void actualizarListaPelicula()
        {
            NPelicula gestionPelicula = new NPelicula();
            listaPeliculas = gestionPelicula.ObtenerListaPeliculas();
        }
        private void Filtrar()
        {
            var resultado = (
                from Pelicula in listaPeliculas
                where Pelicula.Nombre.ToUpper().StartsWith(textBox1.Text.ToUpper())
                select Pelicula

                            ).ToList();
            dgvPeliculas.DataSource = resultado;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
            txtaño.Enabled = true;
            txtduracion.Enabled = true;
            txtgenero.Enabled = true;
            txtidioma.Enabled = true;
            txtnombre.Enabled = true;
            txtsubtitulo.Enabled = true;

        }

        private void Deshabilitar()
        {
            txtsubtitulo.Enabled = false;
            txtnombre.Enabled = false;
            txtidioma.Enabled = false;
            txtgenero.Enabled = false;
            txtduracion.Enabled = false;
            txtaño.Enabled = false;
        }
        private void Limpiar()
        {
            txtaño.Text = "";
            txtduracion.Text = "";
            txtgenero.Text = "";
            txtidioma.Text = "";
            txtnombre.Text = "";
            txtsubtitulo.Text = "";
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            btneliminar.Enabled = false;
            modificar = true;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seguro de querer eliminar este registro", "Pelicula", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EPelicula borrar = new EPelicula();
                    borrar.Id_Pelicula = Convert.ToInt32(txtnombre.Tag);
                    NPelicula gestionPeli = new NPelicula();
                    gestionPeli.Eliminar(borrar);
                    Limpiar();
                    actualizarListaPelicula();
                    dgvPeliculas.DataSource = listaPeliculas;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EPelicula modPelicula = new EPelicula();
                    modPelicula.Id_Pelicula = Convert.ToInt32(txtnombre.Tag.ToString());
                    modPelicula.Nombre = txtnombre.Text;
                    modPelicula.Genero = txtgenero.Text;
                    modPelicula.Idioma = txtidioma.Text;
                    modPelicula.Año = Convert.ToInt32(txtaño.Text);
                    modPelicula.Subtitulo = txtsubtitulo.Text;
                    modPelicula.Duracion = TimeSpan.Parse(txtduracion.Text);

                    NPelicula gestionpeli = new NPelicula();
                    gestionpeli.Modificar(modPelicula);
                    MessageBox.Show("Se modifico correctamente", "Pelicula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    EPelicula nuevaPelicula = new EPelicula();
                    nuevaPelicula.Nombre = txtnombre.Text;
                    nuevaPelicula.Genero = txtgenero.Text;
                    nuevaPelicula.Idioma = txtidioma.Text;
                    nuevaPelicula.Subtitulo = txtsubtitulo.Text;
                    nuevaPelicula.Año = Convert.ToInt32(txtaño.Text);
                    nuevaPelicula.Duracion = TimeSpan.Parse(txtduracion.Text);

                    NPelicula gestionPeliculas = new NPelicula();
                    gestionPeliculas.Agregar(nuevaPelicula);
                    MessageBox.Show("Se guardo correctamente", "Pelicula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                actualizarListaPelicula();
                dgvPeliculas.DataSource = listaPeliculas;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPeliculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                txtnombre.Tag = Convert.ToInt32(dgvPeliculas.Rows[e.RowIndex].Cells["Id_Pelicula"].Value.ToString());
                if (dgvPeliculas.Rows[e.RowIndex].Cells["Nombre"].Value == null)
                    txtnombre.Text = "";
                else
                    txtnombre.Text = dgvPeliculas.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                if (dgvPeliculas.Rows[e.RowIndex].Cells["Genero"].Value == null)
                    txtgenero.Text = "";
                else
                    txtgenero.Text = dgvPeliculas.Rows[e.RowIndex].Cells["Genero"].Value.ToString();

                if (dgvPeliculas.Rows[e.RowIndex].Cells["Idioma"].Value == null)
                    txtidioma.Text = "";
                else
                    txtidioma.Text = dgvPeliculas.Rows[e.RowIndex].Cells["Idioma"].Value.ToString();

                if (dgvPeliculas.Rows[e.RowIndex].Cells["Subtitulo"].Value == null)
                    txtsubtitulo.Text = "";
                else
                    txtsubtitulo.Text = dgvPeliculas.Rows[e.RowIndex].Cells["Subtitulo"].Value.ToString();

                if (dgvPeliculas.Rows[e.RowIndex].Cells["Año"].Value == null)
                    txtaño.Text = "";
                else
                    txtaño.Text = dgvPeliculas.Rows[e.RowIndex].Cells["Año"].Value.ToString();

                if (dgvPeliculas.Rows[e.RowIndex].Cells["Duracion"].Value == null)
                    txtduracion.Text = "";
                else
                    txtduracion.Text = dgvPeliculas.Rows[e.RowIndex].Cells["Duracion"].Value.ToString();

                btnmodificar.Enabled = true;
                btneliminar.Enabled = true;
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
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

       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
            this.Close();
        }
    }
}
