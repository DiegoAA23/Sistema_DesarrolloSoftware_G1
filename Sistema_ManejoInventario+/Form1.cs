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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;

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
            SqlCommand comando = new SqlCommand(consulta, conexion.conectardb);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                conexion.cerrar();
                conexion.abrir();
                cmd = new SqlCommand(consulta, conexion.conectardb);
                SqlDataAdapter user = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                user.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        conexion.Codigo = 1;
                    }

                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();
                    this.Hide();
                }
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
