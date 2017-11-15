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
    public partial class FrmCartelera : Form
    {
        List<ECartelera> listaCar;
        bool modificar;
        public FrmCartelera()
        {
            InitializeComponent();
            Deshabilitar();
            btnbuscarpeli.Enabled = false;
            btnbuscarsala.Enabled = false;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            btnguardar.Enabled = false;

        }
        protected override void WndProc(ref Message m)
        {
           base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
        }

        private void FrmCartelera_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarcartelera();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void actualizarcartelera()
        {
            try
            {
                NCartelera listacartelera = new NCartelera();
                listaCar = listacartelera.listacartelera();

                var lista = (from car in listaCar
                             select new
                             {
                                 car.Id_Cartelera,
                                 Pelicula = car.Id_Pelicula.Nombre,
                                 Sala = car.Id_Sala.nombre,
                                 car.Fecha,
                                 car.Hora,
                                 car.valor,
                                 car.Id_Pelicula.IdPelicula,
                                 car.Id_Sala.IdSala
                             }).ToList();
                dgvCartelera.DataSource = lista;
               dgvCartelera.Columns["IdPelicula"].Visible = false;
                dgvCartelera.Columns["IdSala"].Visible = false;
                dgvCartelera.Columns["Id_Cartelera"].Visible = false ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Habilitar()
        {
            txtpelicula.Enabled = true;
            txtValor.Enabled = true;
            txtsala.Enabled = true;
            dtpFecha.Enabled = true;
            dtpHora.Enabled = true;
        }
        public void Deshabilitar()
        {
            txtpelicula.Enabled = false;
            txtValor.Enabled = false;
            txtsala.Enabled = false;
            dtpFecha.Enabled = false;
            dtpHora.Enabled = false;
        }
        public void Limpiar()
        {
            txtpelicula.Text = "";
            txtpelicula.Tag = "";
            txtValor.Text = "";
            txtsala.Text = "";
            txtsala.Tag = "";
            dtpFecha.Text = "";
            dtpHora.Text = "";
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    

                    ECartelera modCarte= new ECartelera();
                    modCarte.Id_Cartelera=Convert.ToInt32(txtValor.Tag);
                    modCarte.Id_Pelicula.Nombre = txtpelicula.Text;
                    modCarte.Id_Pelicula.IdPelicula = Convert.ToInt32(txtpelicula.Tag);
                    modCarte.Id_Sala.nombre = txtsala.Text;
                    modCarte.Id_Sala.IdSala = Convert.ToInt32(txtsala.Tag);
                    modCarte.Fecha = Convert.ToDateTime(dtpFecha.Text);
                    modCarte.Hora = TimeSpan.Parse(dtpHora.Text);


                    if(Convert.ToDecimal(txtValor.Text) <= 0)
                        throw new ArgumentException("Ingrese un valor valido");
                    else
                        modCarte.valor = Convert.ToDecimal(txtValor.Text);

                    NCartelera modificarcartela = new NCartelera();
                    modificarcartela.Modificar(modCarte);
                    MessageBox.Show("Se guardo correctamente", "Cartelera", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else 
                {
                    ECartelera datosCarte = new ECartelera();
                    datosCarte.Id_Pelicula.Nombre = txtpelicula.Text;
                    datosCarte.Id_Pelicula.IdPelicula =Convert.ToInt32(txtpelicula.Tag);
                    datosCarte.Id_Sala.nombre = txtsala.Text;
                    datosCarte.Id_Sala.IdSala = Convert.ToInt32(txtsala.Tag);
                    datosCarte.Fecha =Convert.ToDateTime(dtpFecha.Text);
                    datosCarte.Hora = TimeSpan.Parse(dtpHora.Text);
                    if (Convert.ToDecimal(txtValor.Text) <= 0)
                    {
                        txtValor.Text = "";
                        throw new ArgumentException("Ingrese un valor valido");
                        
                    }
                    else
                        datosCarte.valor = Convert.ToDecimal(txtValor.Text);

                    NCartelera agregarcarte = new NCartelera();
                    agregarcarte.agregarCartelera(datosCarte);
                    MessageBox.Show("Se guardo correctamente", "Cartelera", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
               actualizarcartelera();
                
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btneliminar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                btnbuscarpeli.Enabled = false;
                btnbuscarsala.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Cartelera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




             
        }

        private void btnbuscarpeli_Click(object sender, EventArgs e)
        {
            FrmBuscarPeli buscarpeli = new FrmBuscarPeli();

            if(buscarpeli.ShowDialog()==DialogResult.OK)
            {
                txtpelicula.Text = buscarpeli.pelicula.ToString();
                txtpelicula.Tag = buscarpeli.idPelicula.ToString();
            }
        }

        private void btnbuscarsala_Click(object sender, EventArgs e)
        {
            FrmBuscarSala buscarsala = new FrmBuscarSala();

            if(buscarsala.ShowDialog()==DialogResult.OK)
            {
                txtsala.Text = buscarsala.sala.ToString();
                txtsala.Tag = buscarsala.idsala.ToString();
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();          
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnbuscarsala.Enabled = true;
            btnbuscarpeli.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            btnnuevo.Enabled = false;
            txtpelicula.Enabled = false;
            txtsala.Enabled = false;
            dgvCartelera.CurrentCell = null;
            
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnbuscarpeli.Enabled = true;
            btnbuscarsala.Enabled = true;       
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            btneliminar.Enabled = false;
            modificar = true;
                      
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btneliminar.Enabled = false;
            btnmodificar.Enabled = false;
        }

        private void dgvCartelera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                txtValor.Tag = Convert.ToInt32(dgvCartelera.Rows[e.RowIndex].Cells["Id_Cartelera"].Value.ToString());
                txtpelicula.Tag = Convert.ToInt32(dgvCartelera.Rows[e.RowIndex].Cells["IdPelicula"].Value.ToString());
                txtsala.Tag = dgvCartelera.Rows[e.RowIndex].Cells["IdSala"].Value.ToString();
                dtpFecha.Text = dgvCartelera.Rows[e.RowIndex].Cells["Fecha"].Value.ToString();
                dtpHora.Text = dgvCartelera.Rows[e.RowIndex].Cells["Hora"].Value.ToString();
                txtValor.Text = dgvCartelera.Rows[e.RowIndex].Cells["Valor"].Value.ToString();
                txtpelicula.Text = dgvCartelera.Rows[e.RowIndex].Cells["Pelicula"].Value.ToString();
                txtsala.Text = dgvCartelera.Rows[e.RowIndex].Cells["Sala"].Value.ToString();
               

                btnmodificar.Enabled = true;
                btneliminar.Enabled = true;
                Deshabilitar();
                
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seguro que deseas eliminar este registro", "CARTELERA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ECartelera eliminar = new ECartelera();
                    eliminar.Id_Cartelera = Convert.ToInt32(txtValor.Tag);
                    NCartelera datoseliminar = new NCartelera();
                    datoseliminar.eliminracarte(eliminar);
                    Limpiar();
                    actualizarcartelera();
                    //dgvSala.DataSource = listasala;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
