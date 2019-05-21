namespace Sistema_inventarios
{
    partial class Retiro_de_Activos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Retiro_de_Activos));
            this.txtcodigo = new System.Windows.Forms.MaskedTextBox();
            this.bteliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datagridactivo = new System.Windows.Forms.DataGridView();
            this.btsalir = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridactivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(309, 84);
            this.txtcodigo.Mask = "0000-000-000-00-00000";
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(145, 20);
            this.txtcodigo.TabIndex = 0;
            // 
            // bteliminar
            // 
            this.bteliminar.FlatAppearance.BorderSize = 0;
            this.bteliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bteliminar.Image = ((System.Drawing.Image)(resources.GetObject("bteliminar.Image")));
            this.bteliminar.Location = new System.Drawing.Point(460, 72);
            this.bteliminar.Name = "bteliminar";
            this.bteliminar.Size = new System.Drawing.Size(52, 46);
            this.bteliminar.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bteliminar, "Remover activo");
            this.bteliminar.UseVisualStyleBackColor = true;
            this.bteliminar.Click += new System.EventHandler(this.bteliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo del Activo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Retiro de Activos";
            // 
            // datagridactivo
            // 
            this.datagridactivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridactivo.Location = new System.Drawing.Point(12, 154);
            this.datagridactivo.Name = "datagridactivo";
            this.datagridactivo.RowTemplate.Height = 24;
            this.datagridactivo.Size = new System.Drawing.Size(1030, 122);
            this.datagridactivo.TabIndex = 4;
            // 
            // btsalir
            // 
            this.btsalir.FlatAppearance.BorderSize = 0;
            this.btsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btsalir.Image = ((System.Drawing.Image)(resources.GetObject("btsalir.Image")));
            this.btsalir.Location = new System.Drawing.Point(22, 307);
            this.btsalir.Name = "btsalir";
            this.btsalir.Size = new System.Drawing.Size(95, 74);
            this.btsalir.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btsalir, "Salir");
            this.btsalir.UseVisualStyleBackColor = true;
            this.btsalir.Click += new System.EventHandler(this.btsalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "LL Lourdes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "UCSFI Colón";
            // 
            // Retiro_de_Activos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1088, 405);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btsalir);
            this.Controls.Add(this.datagridactivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bteliminar);
            this.Controls.Add(this.txtcodigo);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Retiro_de_Activos";
            this.Text = "Retiro de Activos";
            ((System.ComponentModel.ISupportInitialize)(this.datagridactivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtcodigo;
        private System.Windows.Forms.Button bteliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView datagridactivo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btsalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}