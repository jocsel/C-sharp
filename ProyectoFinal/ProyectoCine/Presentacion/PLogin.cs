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
    public partial class PLogin : Form
    {
        public PLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /// Environment.Exit(0);
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Environment.Exit(0);
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {try
            {
                EUsuario logusuario = new EUsuario();
                logusuario.Nombre_Usuario = txtusuario.Text;
                logusuario.Contraseña = txtcontrasena.Text;
                NUsuario gesusuario = new NUsuario();
                //gesusuario.logeo(logusuario);

                DataTable tabla = new DataTable();
                tabla = gesusuario.logeo(logusuario);

                if (tabla.Rows.Count > 0)
                {
                    logusuario.Nombre_Usuario = tabla.Rows[0][0].ToString();
                    logusuario.Contraseña = tabla.Rows[0][1].ToString();
                    FrmInicio inicio = new FrmInicio();
                    this.Hide();
                    inicio.Show();
                    
                }
                else
                {
                    throw new ArgumentException("Contrase;a o Usuario incorecto");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
