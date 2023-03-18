using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ManejoInventario_
{
    public partial class ReporteInventario : Form
    {
        clsReporteInventario ri = new clsReporteInventario();
        Conexion cone = new Conexion();
        Conexion conexion = new Conexion();
        SqlDataAdapter data_adapter;
        DataTable tabla_reportes;
        public ReporteInventario()
        {
            InitializeComponent();
        }

        private void ReporteInventario_Load(object sender, EventArgs e)
        {
            cone.abrir();
            ri.MostrarInventario(dataGridView1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ri.Buscar(dataGridView1, this.textBox1.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == String.Empty)
                {

                    MessageBox.Show("Ingrese un codigo para buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    conexion.abrir();
                    int cod = Convert.ToInt16(textBox1.Text);
                    String consulta = "Select * from Productos where Codigo = " + cod;
                    data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
                    tabla_reportes = new DataTable();
                    data_adapter.Fill(tabla_reportes);
                    dataGridView1.DataSource = tabla_reportes;
                    conexion.cerrar();
                }
            }
            catch
            {
                MessageBox.Show("Error al buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
