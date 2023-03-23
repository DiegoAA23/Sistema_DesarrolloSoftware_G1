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
    public partial class CrearReporte : Form
    {
        public CrearReporte()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();
        SqlDataAdapter data_adapter;
        DataTable tabla_reportes;
        Conexion cone = new Conexion();
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Seleccionar un codigo para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CrearReporte_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenarReportes();
        }

        private DataTable llenarReportes()
        {
            conexion.abrir();
            String consulta = "SELECT * FROM ReporteInfo";
            data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
            tabla_reportes = new DataTable();
            data_adapter.Fill(tabla_reportes);
            conexion.cerrar();

            return tabla_reportes;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if(textBox1.Text == String.Empty) {

                    MessageBox.Show("Ingrese un codigo para buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    conexion.abrir();
                    int cod = Convert.ToInt16(textBox1.Text);
                    String consulta = "Select * from Reportes where Numero = " + cod;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.DataSource = llenarReportes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportesAgregar ra = new ReportesAgregar();
            ra.Show();
        }
    }
}
