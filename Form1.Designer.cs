namespace GestionContenedores
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTp = new System.Windows.Forms.TextBox();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.txtReporte = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdBuscar = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtForzarCarga = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingresar Contenedor:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo Producto: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Peso en kilogramos: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTp
            // 
            this.txtTp.BackColor = System.Drawing.Color.White;
            this.txtTp.Location = new System.Drawing.Point(205, 52);
            this.txtTp.Margin = new System.Windows.Forms.Padding(2);
            this.txtTp.Multiline = true;
            this.txtTp.Name = "txtTp";
            this.txtTp.Size = new System.Drawing.Size(198, 24);
            this.txtTp.TabIndex = 6;
            this.txtTp.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtKg
            // 
            this.txtKg.BackColor = System.Drawing.Color.White;
            this.txtKg.Location = new System.Drawing.Point(205, 92);
            this.txtKg.Margin = new System.Windows.Forms.Padding(2);
            this.txtKg.Multiline = true;
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(76, 24);
            this.txtKg.TabIndex = 7;
            this.txtKg.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtReporte
            // 
            this.txtReporte.BackColor = System.Drawing.Color.White;
            this.txtReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReporte.Enabled = false;
            this.txtReporte.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReporte.ForeColor = System.Drawing.Color.Black;
            this.txtReporte.Location = new System.Drawing.Point(557, 125);
            this.txtReporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtReporte.Multiline = true;
            this.txtReporte.Name = "txtReporte";
            this.txtReporte.Size = new System.Drawing.Size(451, 265);
            this.txtReporte.TabIndex = 8;
            this.txtReporte.TextChanged += new System.EventHandler(this.txtReporte_TextChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresar.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(127, 133);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(182, 34);
            this.btnIngresar.TabIndex = 9;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-3, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(465, 37);
            this.label4.TabIndex = 10;
            this.label4.Text = "Información acerca de contenedor:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID Contenedor: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtIdBuscar
            // 
            this.txtIdBuscar.BackColor = System.Drawing.Color.White;
            this.txtIdBuscar.Location = new System.Drawing.Point(205, 60);
            this.txtIdBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdBuscar.Multiline = true;
            this.txtIdBuscar.Name = "txtIdBuscar";
            this.txtIdBuscar.Size = new System.Drawing.Size(76, 24);
            this.txtIdBuscar.TabIndex = 12;
            this.txtIdBuscar.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReport.Location = new System.Drawing.Point(127, 112);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(182, 34);
            this.btnReport.TabIndex = 13;
            this.btnReport.Text = "Reportar";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(702, 405);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-3, -3);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(388, 37);
            this.label6.TabIndex = 15;
            this.label6.Text = "Realizar carga manualmente:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Id Contenedor:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtForzarCarga
            // 
            this.txtForzarCarga.BackColor = System.Drawing.Color.White;
            this.txtForzarCarga.Location = new System.Drawing.Point(205, 62);
            this.txtForzarCarga.Margin = new System.Windows.Forms.Padding(2);
            this.txtForzarCarga.Multiline = true;
            this.txtForzarCarga.Name = "txtForzarCarga";
            this.txtForzarCarga.Size = new System.Drawing.Size(76, 24);
            this.txtForzarCarga.TabIndex = 17;
            this.txtForzarCarga.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(127, 111);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 34);
            this.button3.TabIndex = 19;
            this.button3.Text = "Cargar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKg);
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 184);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIdBuscar);
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Location = new System.Drawing.Point(22, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 162);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtForzarCarga);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(22, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(467, 162);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.BackgroundImage = global::GestionContenedores.Properties.Resources.prueba;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 564);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtReporte);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Gestion Contenedores";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTp;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.TextBox txtReporte;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdBuscar;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtForzarCarga;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

