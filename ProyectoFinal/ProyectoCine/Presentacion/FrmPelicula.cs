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
        public FrmPelicula()
        {
            InitializeComponent();
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarLista();
                dgvPeliculas.DataSource = listaPeliculas;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void actualizarLista()
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
    }
}
