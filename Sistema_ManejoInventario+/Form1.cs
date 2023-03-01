using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_ManejoInventario_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();
        SqlCommand cmd;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            conexion.abrir();
            string consulta = "select * from Usuarios where Nombre='" + txtUsuario.Text + "'and Contrasena='" + TxtContraseña.Text + "'";
            SqlCommand comando = new SqlCommand(consulta,conexion.conectardb);
            SqlDataReader lector;
            lector = comando.ExecuteReader();
            if (lector.HasRows == true)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto.");
                txtUsuario.Text = "";
                TxtContraseña.Text = "";
            }
            conexion.cerrar();
            
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
