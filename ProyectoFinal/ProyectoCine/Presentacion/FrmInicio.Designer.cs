namespace Presentacion
{
    partial class FrmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSucursal = new System.Windows.Forms.PictureBox();
            this.pbPelicula = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPelicula)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSucursal
            // 
            this.pbSucursal.BackColor = System.Drawing.Color.Transparent;
            this.pbSucursal.Image = global::Presentacion.Properties.Resources.ubicacion_icono;
            this.pbSucursal.Location = new System.Drawing.Point(272, 152);
            this.pbSucursal.Name = "pbSucursal";
            this.pbSucursal.Size = new System.Drawing.Size(110, 103);
            this.pbSucursal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSucursal.TabIndex = 1;
            this.pbSucursal.TabStop = false;
            // 
            // pbPelicula
            // 
            this.pbPelicula.BackColor = System.Drawing.Color.Transparent;
            this.pbPelicula.Image = global::Presentacion.Properties.Resources.Apps_Google_Movies_icon;
            this.pbPelicula.Location = new System.Drawing.Point(128, 152);
            this.pbPelicula.Name = "pbPelicula";
            this.pbPelicula.Size = new System.Drawing.Size(104, 103);
            this.pbPelicula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPelicula.TabIndex = 0;
            this.pbPelicula.TabStop = false;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 428);
            this.Controls.Add(this.pbSucursal);
            this.Controls.Add(this.pbPelicula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)(this.pbSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPelicula)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPelicula;
        private System.Windows.Forms.PictureBox pbSucursal;
    }
}