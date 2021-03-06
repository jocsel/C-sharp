﻿using System;
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
    public partial class FrmVenta : Form
    {
        List<EVenta> listaventas;
        public FrmVenta()
        {
            InitializeComponent();
            Deshabilitar();
            
            btnImprimir.Enabled = false;
            btnGuardar.Enabled = false;
            btncancelar.Enabled = false;
            btnCartelera.Enabled = false;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicio inicio = new FrmInicio();
            inicio.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
           try{
                actulizarVenta();
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void actulizarVenta() {
            try {
                NVenta listaVenta = new NVenta();
                listaventas = listaVenta.listVenta();

                var lista = (from listarVentas in listaventas
                             select new
                             {
                                 listarVentas.IdVenta,
                                 listarVentas.IdCartelera.Id_Cartelera,
                                 Pelicula =listarVentas.IdCartelera.Id_Pelicula.Nombre,
                                 Sala =listarVentas.IdCartelera.Id_Sala.nombre,
                                 listarVentas.Fecha,
                                 listarVentas.Hora,
                                 Tickets= listarVentas.NumTicket,
                                 Valor=listarVentas.IdCartelera.valor,
                                 listarVentas.CostoTotal

                             }).ToList();
                
                dgvVentas.DataSource = lista;
                dgvVentas.Columns["IdVenta"].Visible = false;
                 dgvVentas.Columns["Id_Cartelera"].Visible = false;
            }
            catch (Exception ex) {

                throw ex;
            }
            
        }

        public void Habilitar() {
            txtCostoTotal.Enabled = true;
            txtCartelera.Enabled = true;
            dtpFecha.Enabled = true;
            dtpHora.Enabled = true;
            nudNumTicket.Enabled = true;
        }

        public void Deshabilitar() {
            txtCostoTotal.Enabled = false;
            txtCartelera.Enabled = false;
            dtpFecha.Enabled = false;
            dtpHora.Enabled = false;
            nudNumTicket.Enabled = false;

        }

        public void Limpiar() {
            txtCartelera.Text = "";
            txtCartelera.Tag = "";
            nudNumTicket.ResetText();
            txtCostoTotal.Text = "";
            dtpFecha.Text = "";
            dtpHora.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try {
                EVenta datosVenta = new EVenta();

                datosVenta.IdCartelera.Id_Cartelera = Convert.ToInt32(txtCartelera.Tag);
                datosVenta.IdCartelera.Id_Pelicula.Nombre =txtCartelera.Text;
                datosVenta.Fecha = Convert.ToDateTime(dtpFecha.Text);
                datosVenta.Hora = TimeSpan.Parse(dtpHora.Text);
                datosVenta.NumTicket = Convert.ToInt32(nudNumTicket.Text);
                datosVenta.CostoTotal = Convert.ToDecimal(txtCostoTotal.Text);
                datosVenta.IdCartelera.valor = Convert.ToDecimal(txtCostoTotal.Tag);
                NVenta agregarVenta = new NVenta();
                agregarVenta.agregarVenta(datosVenta);
                MessageBox.Show("Se guardo correctamente", "Venta Realizada",MessageBoxButtons.OK,MessageBoxIcon.Information);

                actulizarVenta();
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnCartelera.Enabled = false;
                btnGuardar.Enabled = false;
                btnImprimir.Enabled = true;
                btnnuevo.Enabled = true;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
        
        private void btnCartelera_Click(object sender, EventArgs e)
        {
            FrmBuscarCartelera buscarCartelera = new FrmBuscarCartelera();
            if (buscarCartelera.ShowDialog() == DialogResult.OK)
            {
                txtCartelera.Text = buscarCartelera.Pelicula.ToString();
                txtCartelera.Tag = buscarCartelera.idcartelera.ToString();
                txtCostoTotal.Tag = buscarCartelera.valor.ToString();


            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btncancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnCartelera.Enabled = true;
            btnImprimir.Enabled = false;
            btnnuevo.Enabled = false;
            txtCartelera.Enabled = false;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnImprimir.Enabled = false;
            btncancelar.Enabled = false;
            btnCartelera.Enabled = false;
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex >= 0) {
                txtCartelera.Tag = dgvVentas.Rows[e.RowIndex].Cells["IdVenta"].Value.ToString();
                txtCartelera.Text = dgvVentas.Rows[e.RowIndex].Cells["IdCartelera"].Value.ToString();
                txtCostoTotal.Tag = dgvVentas.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtCostoTotal.Tag = dgvVentas.Rows[e.RowIndex].Cells["Id_Sala"].Value.ToString();
                dtpFecha.Text = dgvVentas.Rows[e.RowIndex].Cells["Fecha"].Value.ToString();
                dtpHora.Text = dgvVentas.Rows[e.RowIndex].Cells["Hora"].Value.ToString();
                nudNumTicket.Tag = dgvVentas.Rows[e.RowIndex].Cells["NumTicket"].Value.ToString();
                txtCostoTotal.Tag = dgvVentas.Rows[e.RowIndex].Cells["valor"].Value.ToString();
                txtCostoTotal.Text = dgvVentas.Rows[e.RowIndex].Cells["CostoTotal"].Value.ToString();
                Deshabilitar();
            }
            */
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void nudNumTicket_Click(object sender, EventArgs e)
        {
            decimal costo = Convert.ToDecimal(txtCostoTotal.Tag);
            decimal valor = Convert.ToDecimal(nudNumTicket.Value);
            txtCostoTotal.Text = Convert.ToString(costo*valor);
            
        }
    }
}
