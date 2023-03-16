using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ManejoInventario_
{
    public partial class Ventas : Form
    {

        Conexion conexion = new Conexion();
        SqlDataAdapter data_adapter;
        DataTable tabla_ventas;
        SqlCommand cmd;
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            dgv_Ventas.DataSource = llenarVentas();
            lblfact.Hide();
            lblultima.Hide();  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DataTable llenarVentas()
        {
            conexion.abrir();
            String consulta = "Select * from FacturaCompleta";
            data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
            tabla_ventas = new DataTable();
            data_adapter.Fill(tabla_ventas);
            conexion.cerrar();

            return tabla_ventas;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridview1_RowHeaderMouseClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtBusquedaV.Text == String.Empty)
            {
                MessageBox.Show("Ingrese un codigo para realizar la busqueda correctamente", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBusquedaV.Focus();
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
                conexion.abrir();
                String codigov = txtBusquedaV.Text;
                String consulta = "Select * from Factura_Detalle Where Factura = " + codigov;
                data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
                tabla_ventas = new DataTable();
                data_adapter.Fill(tabla_ventas);
                conexion.cerrar();

                dgv_Ventas.DataSource = tabla_ventas;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBusquedaV.Clear();
            dgv_Ventas.DataSource = llenarVentas();
            txtBusquedaV.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DetalleFactura df = new DetalleFactura();
            df.Show();
            df.FormClosing += new FormClosingEventHandler(this.DetalleFactura_FormClosing);
                  
        }
        private void DetalleFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBusquedaV.Clear();
            dgv_Ventas.DataSource = llenarVentas();
            txtBusquedaV.Enabled = true;

            conexion.abrir();
            int factura = 0;
            cmd = new SqlCommand("Select * from Factura", conexion.conectardb);
            string query = ("SELECT MAX(Codigo) AS Codigo FROM Factura");
            SqlCommand com = new SqlCommand(query, conexion.conectardb);
            SqlDataReader reg = com.ExecuteReader();
            while (reg.Read())
            {
                factura = Convert.ToInt16((reg["Codigo"]));
            }
            conexion.cerrar();
            lblfact.Show();
            lblultima.Show();
            lblultima.Text = factura.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No ha ingresado datos sobre la factura", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conexion.abrir();
            try
            {
                if (txtBusquedaV.Text != String.Empty)
                {

                    DialogResult d = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if(d == DialogResult.Yes)
                    {
                        string borrar = "Delete From Detalle Where Factura_Codigo = @c;";
                        
                        using (SqlCommand command = new SqlCommand(borrar, conexion.conectardb))
                        {
                            command.Parameters.AddWithValue("@c", txtBusquedaV.Text);
                            command.ExecuteNonQuery();
                        }

                        string borrar2 = "Delete From Factura Where Codigo = @c;";
                        using (SqlCommand command = new SqlCommand(borrar2, conexion.conectardb))
                        {
                            command.Parameters.AddWithValue("@c", txtBusquedaV.Text);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Registro eliminado con exito", "COMPLETADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_Ventas.DataSource = llenarVentas();
                    }
                }
                else
                {
                    MessageBox.Show("No ha ingresado un codigo de factura", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el registro\n" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion.cerrar();
            txtBusquedaV.Clear();
            txtBusquedaV.Enabled = true;
        }

        private void dgv_Ventas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;

            txtBusquedaV.Text = dgv_Ventas.CurrentRow.Cells[0].Value.ToString();
            txtBusquedaV.Enabled = false;
        }
    }
}
