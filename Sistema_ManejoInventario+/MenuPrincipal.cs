﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sistema_ManejoInventario_
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
     
            BtnMaximizar.Visible = true;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnNormal.Visible = true;
            BtnMaximizar.Visible = false;
            
            
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AbrirFormHijo(object formhijo)
        {
            if (this.PanelCentro.Controls.Count > 0)
                this.PanelCentro.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelCentro.Controls.Add(fh);
            this.PanelCentro.Tag = fh;
            fh.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Inventario());

        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Ventas());
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new CrearReporte());
        }

        private void BtnMenuPrincipal_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new VentanaMenuPrincipal());
            


        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
          /*  lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();*/
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnNormal.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BarraTop_MouseDown(object sender, MouseEventArgs e)
        {
            
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
