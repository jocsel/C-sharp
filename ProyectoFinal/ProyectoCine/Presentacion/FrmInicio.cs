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

namespace Presentacion
{
    public partial class FrmInicio : Form
    {
        public string  tipousuario;
        public FrmInicio()
        {
            InitializeComponent();
            
            
           

        }

        private void pbPelicula_Click(object sender, EventArgs e)
        {

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Global.usuarioSesion.Nombres;
            pictureBox1.Enabled = Global.usuarioSesion.Permiso.Sucursal; 
            pictureBox6.Enabled = Global.usuarioSesion.Permiso.Sala; //SE BLOQUEA JUNTO CON PELICULA
            pictureBox5.Enabled = Global.usuarioSesion.Permiso.Pelicula; 
            pictureBox2.Enabled = Global.usuarioSesion.Permiso.Cartelera; 
            pictureBox3.Enabled = Global.usuarioSesion.Permiso.Venta; 
            pictureBox4.Enabled = Global.usuarioSesion.Permiso.User; 
           // pictureBox10.Enabled = Global.usuarioSesion.Permiso.Salir;  
            
                /* if(tipousuario=="Empleado")
            {
               
                pictureBox1.Enabled = false;
                pictureBox6.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox5.Enabled = false;
                pictureBox4.Enabled = false;
            }*/
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmSucursal sucursal = new FrmSucursal();
            this.Hide();
            sucursal.Show();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmSala sala = new FrmSala();
            sala.Show();
            this.Hide();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmPelicula pelicula = new FrmPelicula();
            pelicula.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            
            FrmCartelera cartelera = new FrmCartelera();
            this.Hide();
            cartelera.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmVenta venta = new FrmVenta();

            venta.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmUsuario usuario = new FrmUsuario();
            usuario.Show();
            this.Hide();
        }



        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(Properties.Resources.sucursal1);

        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(Properties.Resources.sucursal);
        }

        private void pictureBox2_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(Properties.Resources.cartelera1);
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(Properties.Resources.cartelera);
        }

        private void pictureBox6_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox6.Image = new Bitmap(Properties.Resources.sala2);
           

        }

        private void pictureBox6_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox6.Image = new Bitmap(Properties.Resources.sala1);
        }

        private void pictureBox5_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox5.Image = new Bitmap(Properties.Resources.pelii1);
        }

        private void pictureBox5_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox5.Image = new Bitmap(Properties.Resources.pelii2);
        }

        private void pictureBox3_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox3.Image = new Bitmap(Properties.Resources.venta1);
        }

        private void pictureBox3_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox3.Image = new Bitmap(Properties.Resources.venta);

        }

        private void pictureBox4_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox4.Image = new Bitmap(Properties.Resources.usuario1);

        }

        private void pictureBox4_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox4.Image = new Bitmap(Properties.Resources.usuario);
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = new Bitmap(Properties.Resources.salir1);
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Image = new Bitmap(Properties.Resources.salir);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
   
    }
}
