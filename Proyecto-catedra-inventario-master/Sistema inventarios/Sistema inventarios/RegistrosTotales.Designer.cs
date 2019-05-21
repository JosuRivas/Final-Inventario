namespace Sistema_inventarios
{
    partial class RegistrosTotales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrosTotales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSalir = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.datagridRegistros = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "UCSFI Colón";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "LL Lourdes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(356, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(501, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Registros actuales de Activo Fijo en el sistema";
            // 
            // btSalir
            // 
            this.btSalir.BackColor = System.Drawing.Color.Transparent;
            this.btSalir.FlatAppearance.BorderSize = 0;
            this.btSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalir.Image = ((System.Drawing.Image)(resources.GetObject("btSalir.Image")));
            this.btSalir.Location = new System.Drawing.Point(20, 402);
            this.btSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(87, 80);
            this.btSalir.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btSalir, "Salir");
            this.btSalir.UseVisualStyleBackColor = false;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // datagridRegistros
            // 
            this.datagridRegistros.AllowUserToAddRows = false;
            this.datagridRegistros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.datagridRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridRegistros.BackgroundColor = System.Drawing.Color.DarkGray;
            this.datagridRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridRegistros.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridRegistros.GridColor = System.Drawing.Color.Black;
            this.datagridRegistros.Location = new System.Drawing.Point(20, 127);
            this.datagridRegistros.Name = "datagridRegistros";
            this.datagridRegistros.RowTemplate.Height = 24;
            this.datagridRegistros.Size = new System.Drawing.Size(1182, 231);
            this.datagridRegistros.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // RegistrosTotales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1251, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datagridRegistros);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegistrosTotales";
            this.Text = "RegistrosTotales";
            this.Load += new System.EventHandler(this.RegistrosTotales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView datagridRegistros;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}