namespace Presentacion
{
    partial class FrmUsuario
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.lblnombreapellido = new System.Windows.Forms.Label();
            this.lblcontraseña = new System.Windows.Forms.Label();
            this.lbltipousuario = new System.Windows.Forms.Label();
            this.txtxContraseña = new System.Windows.Forms.TextBox();
            this.txtnombreapellido = new System.Windows.Forms.TextBox();
            this.cbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFiltrar = new System.Windows.Forms.GroupBox();
            this.lblFiltrarNombre = new System.Windows.Forms.Label();
            this.txtFiltrarUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblusuario = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbFiltrar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnguardar);
            this.groupBox2.Controls.Add(this.btncancelar);
            this.groupBox2.Controls.Add(this.btneliminar);
            this.groupBox2.Controls.Add(this.btnmodificar);
            this.groupBox2.Controls.Add(this.btnnuevo);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funciones";
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(379, 21);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(95, 28);
            this.btnguardar.TabIndex = 14;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(505, 21);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(95, 28);
            this.btncancelar.TabIndex = 13;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(260, 21);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(95, 28);
            this.btneliminar.TabIndex = 12;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnmodificar
            // 
            this.btnmodificar.Location = new System.Drawing.Point(139, 21);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(95, 28);
            this.btnmodificar.TabIndex = 11;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = true;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.Location = new System.Drawing.Point(20, 21);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(95, 28);
            this.btnnuevo.TabIndex = 10;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = true;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Location = new System.Drawing.Point(12, 317);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.Size = new System.Drawing.Size(625, 150);
            this.dgvUsuario.TabIndex = 3;
            this.dgvUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellClick);
            this.dgvUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellContentClick);
            // 
            // lblnombreapellido
            // 
            this.lblnombreapellido.AutoSize = true;
            this.lblnombreapellido.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombreapellido.Location = new System.Drawing.Point(17, 31);
            this.lblnombreapellido.Name = "lblnombreapellido";
            this.lblnombreapellido.Size = new System.Drawing.Size(125, 14);
            this.lblnombreapellido.TabIndex = 4;
            this.lblnombreapellido.Text = "Nombre y Apellido:";
            // 
            // lblcontraseña
            // 
            this.lblcontraseña.AutoSize = true;
            this.lblcontraseña.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontraseña.Location = new System.Drawing.Point(350, 63);
            this.lblcontraseña.Name = "lblcontraseña";
            this.lblcontraseña.Size = new System.Drawing.Size(86, 14);
            this.lblcontraseña.TabIndex = 5;
            this.lblcontraseña.Text = "Contraseña:";
            // 
            // lbltipousuario
            // 
            this.lbltipousuario.AutoSize = true;
            this.lbltipousuario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltipousuario.Location = new System.Drawing.Point(350, 31);
            this.lbltipousuario.Name = "lbltipousuario";
            this.lbltipousuario.Size = new System.Drawing.Size(90, 14);
            this.lbltipousuario.TabIndex = 6;
            this.lbltipousuario.Text = "Tipo Usuario:";
            // 
            // txtxContraseña
            // 
            this.txtxContraseña.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxContraseña.Location = new System.Drawing.Point(449, 60);
            this.txtxContraseña.Name = "txtxContraseña";
            this.txtxContraseña.PasswordChar = '*';
            this.txtxContraseña.Size = new System.Drawing.Size(157, 22);
            this.txtxContraseña.TabIndex = 7;
            // 
            // txtnombreapellido
            // 
            this.txtnombreapellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombreapellido.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreapellido.Location = new System.Drawing.Point(143, 28);
            this.txtnombreapellido.Name = "txtnombreapellido";
            this.txtnombreapellido.Size = new System.Drawing.Size(188, 22);
            this.txtnombreapellido.TabIndex = 8;
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoUsuario.FormattingEnabled = true;
            this.cbTipoUsuario.Items.AddRange(new object[] {
            "Admin",
            "Empleado"});
            this.cbTipoUsuario.Location = new System.Drawing.Point(449, 28);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(157, 22);
            this.cbTipoUsuario.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblusuario);
            this.groupBox1.Controls.Add(this.txtNombreUsuario);
            this.groupBox1.Controls.Add(this.lblnombreapellido);
            this.groupBox1.Controls.Add(this.cbTipoUsuario);
            this.groupBox1.Controls.Add(this.lblcontraseña);
            this.groupBox1.Controls.Add(this.txtxContraseña);
            this.groupBox1.Controls.Add(this.txtnombreapellido);
            this.groupBox1.Controls.Add(this.lbltipousuario);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 95);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Usuario";
            // 
            // gbFiltrar
            // 
            this.gbFiltrar.Controls.Add(this.lblFiltrarNombre);
            this.gbFiltrar.Controls.Add(this.txtFiltrarUsuario);
            this.gbFiltrar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltrar.Location = new System.Drawing.Point(12, 251);
            this.gbFiltrar.Name = "gbFiltrar";
            this.gbFiltrar.Size = new System.Drawing.Size(625, 48);
            this.gbFiltrar.TabIndex = 11;
            this.gbFiltrar.TabStop = false;
            this.gbFiltrar.Text = "Filtrar";
            // 
            // lblFiltrarNombre
            // 
            this.lblFiltrarNombre.AutoSize = true;
            this.lblFiltrarNombre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrarNombre.Location = new System.Drawing.Point(43, 22);
            this.lblFiltrarNombre.Name = "lblFiltrarNombre";
            this.lblFiltrarNombre.Size = new System.Drawing.Size(65, 14);
            this.lblFiltrarNombre.TabIndex = 1;
            this.lblFiltrarNombre.Text = "Nombre :";
            // 
            // txtFiltrarUsuario
            // 
            this.txtFiltrarUsuario.Location = new System.Drawing.Point(114, 19);
            this.txtFiltrarUsuario.Name = "txtFiltrarUsuario";
            this.txtFiltrarUsuario.Size = new System.Drawing.Size(480, 22);
            this.txtFiltrarUsuario.TabIndex = 0;
            this.txtFiltrarUsuario.TextChanged += new System.EventHandler(this.txtFiltrarUsuario_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(307, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "USUARIO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 29);
            this.panel2.TabIndex = 12;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::Presentacion.Properties.Resources.X;
            this.pictureBox8.Location = new System.Drawing.Point(626, 0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(26, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 2;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(143, 60);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(188, 22);
            this.txtNombreUsuario.TabIndex = 10;
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.Location = new System.Drawing.Point(17, 63);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(60, 14);
            this.lblusuario.TabIndex = 11;
            this.lblusuario.Text = "Usuario:";
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 490);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbFiltrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFiltrar.ResumeLayout(false);
            this.gbFiltrar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.Label lblnombreapellido;
        private System.Windows.Forms.Label lblcontraseña;
        private System.Windows.Forms.Label lbltipousuario;
        private System.Windows.Forms.TextBox txtxContraseña;
        private System.Windows.Forms.TextBox txtnombreapellido;
        private System.Windows.Forms.ComboBox cbTipoUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbFiltrar;
        private System.Windows.Forms.TextBox txtFiltrarUsuario;
        private System.Windows.Forms.Label lblFiltrarNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
    }
}