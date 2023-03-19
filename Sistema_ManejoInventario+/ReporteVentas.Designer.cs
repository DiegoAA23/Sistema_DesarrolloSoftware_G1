namespace Sistema_ManejoInventario_
{
    partial class ReporteVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVentas));
            this.dtpFiltro = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BarraTop = new System.Windows.Forms.Panel();
            this.btnNormal = new System.Windows.Forms.PictureBox();
            this.BtnMinimizar = new System.Windows.Forms.PictureBox();
            this.BtnMaximizar = new System.Windows.Forms.PictureBox();
            this.BtnCerrar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.BarraTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFiltro
            // 
            this.dtpFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltro.Location = new System.Drawing.Point(272, 95);
            this.dtpFiltro.Name = "dtpFiltro";
            this.dtpFiltro.Size = new System.Drawing.Size(279, 26);
            this.dtpFiltro.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(85, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(631, 215);
            this.dataGridView1.TabIndex = 2;
            // 
            // BarraTop
            // 
            this.BarraTop.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BarraTop.Controls.Add(this.btnNormal);
            this.BarraTop.Controls.Add(this.BtnMinimizar);
            this.BarraTop.Controls.Add(this.BtnMaximizar);
            this.BarraTop.Controls.Add(this.BtnCerrar);
            this.BarraTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTop.Location = new System.Drawing.Point(0, 0);
            this.BarraTop.Name = "BarraTop";
            this.BarraTop.Size = new System.Drawing.Size(800, 31);
            this.BarraTop.TabIndex = 34;
            this.BarraTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTop_MouseDown);
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.Image = ((System.Drawing.Image)(resources.GetObject("btnNormal.Image")));
            this.btnNormal.Location = new System.Drawing.Point(723, 3);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(25, 25);
            this.btnNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNormal.TabIndex = 3;
            this.btnNormal.TabStop = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("BtnMinimizar.Image")));
            this.BtnMinimizar.Location = new System.Drawing.Point(686, 3);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.BtnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMinimizar.TabIndex = 2;
            this.BtnMinimizar.TabStop = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // BtnMaximizar
            // 
            this.BtnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("BtnMaximizar.Image")));
            this.BtnMaximizar.Location = new System.Drawing.Point(723, 3);
            this.BtnMaximizar.Name = "BtnMaximizar";
            this.BtnMaximizar.Size = new System.Drawing.Size(25, 25);
            this.BtnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMaximizar.TabIndex = 1;
            this.BtnMaximizar.TabStop = false;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(759, 3);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(25, 25);
            this.BtnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnCerrar.TabIndex = 0;
            this.BtnCerrar.TabStop = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Fecha: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(55)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(298, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 41);
            this.button1.TabIndex = 36;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BarraTop);
            this.Controls.Add(this.dtpFiltro);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteVentas";
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.BarraTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFiltro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel BarraTop;
        private System.Windows.Forms.PictureBox btnNormal;
        private System.Windows.Forms.PictureBox BtnMinimizar;
        private System.Windows.Forms.PictureBox BtnMaximizar;
        private System.Windows.Forms.PictureBox BtnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}