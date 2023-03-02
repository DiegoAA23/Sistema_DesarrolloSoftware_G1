using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ManejoInventario_
{
    public partial class VentanaMenuPrincipal : Form
    {
        public VentanaMenuPrincipal()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();

        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();

            if (conexion.Codigo == 1)
            {
                lblMensaje.Text = "Bienvenido, Administrador";
            }
            else
            {
                lblMensaje.Text = "Bienvenido, Empleado";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
