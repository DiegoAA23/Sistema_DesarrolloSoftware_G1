using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ManejoInventario_
{
    public partial class DetalleFactura : Form
    {
        public DetalleFactura()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();
        SqlDataAdapter data_adapter;
        DataTable tabla_facturas;
        SqlCommand cmd;

        int codigo = 0;
        string nombre = "";
        string precio = "";
        int j = 0;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private const int SombraForm = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= SombraForm;
                return cp;
            }
        }
        
        private DataTable llenarFacturas(){
            conexion.abrir();
            String consulta = "SELECT * FROM Producto_Factura";
            data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
            tabla_facturas = new DataTable();
            data_adapter.Fill(tabla_facturas);
            conexion.cerrar();

            return tabla_facturas;
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            conexion.abrir();

            try
            {
                cmd = new SqlCommand("Select * from Producto_Factura", conexion.conectardb);

                SqlDataReader registro = cmd.ExecuteReader();
                cbxProductos.DisplayMember = "Text";

                while (registro.Read())
                {
                    cbxProductos.Items.Add(new { Text = registro["Nombre"], Value = registro["Codigo"].ToString() });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dato en el ComboBox", "ERROR");
            }
            finally
            {
                conexion.cerrar();
            }

            conexion.abrir();
            
            try
            {
                cmd = new SqlCommand("Select * from MetodoPago", conexion.conectardb);

                SqlDataReader registro = cmd.ExecuteReader();
                cbxPago.DisplayMember = "Text";

                while (registro.Read())
                {
                    cbxPago.Items.Add(new { Text = registro["Nombre"], Value = registro["Codigo"].ToString() });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dato en el ComboBox", "ERROR");
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {

        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNormal_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnNormal.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTop_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void BarraTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void dgvProductosV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_agregados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.abrir();

                if (cbxProductos == null || txtCantidad.Text == String.Empty)
                {
                    MessageBox.Show("No se puede ingresar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dgv_agregados.Rows.Add();
                    string cantidad = txtCantidad.Text;
                    dgv_agregados.Rows[j].Cells[0].Value = nombre;
                    dgv_agregados.Rows[j].Cells[1].Value = precio;
                    dgv_agregados.Rows[j].Cells[2].Value = Convert.ToInt32(cantidad);
                    j++;
                    txtCantidad.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar\n" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conexion.abrir();
                cmd = new SqlCommand("Select * from Productos", conexion.conectardb);

                string consulta = "SELECT * from Productos Where Codigo = '" + (cbxProductos.SelectedItem as dynamic).Value + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.conectardb);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    codigo = Convert.ToInt16((cbxProductos.SelectedItem as dynamic).Value);
                    nombre = Convert.ToString((registro["Nombre"]));
                    precio = Convert.ToString((registro["Precio de Venta"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar\n" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if(txtDNI.Text == String.Empty || cbxPago == null || dtp_fecha.Value.ToString() == "")
                {
                    MessageBox.Show("No puede ingresar campos vacios","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(dgv_agregados.Rows.Count == 1) 
                {
                    MessageBox.Show("Debe ingresar productos en la factura", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // PARA TABLA FACTURA
                    conexion.abrir();
                    string fecha = dtp_fecha.Value.ToString("yyyy/MM/dd");
                    double subtotal = 0;
                    int filas = dgv_agregados.Rows.Count;
                    int c = 0;
                    double p = 0;
                    double s = 0;

                    for (int x = 0; x < filas; x++)
                    {
                        if (dgv_agregados.Rows[x].Cells[1].Value != null && dgv_agregados.Rows[x].Cells[2].Value != null)
                        {
                            c = Convert.ToInt32(dgv_agregados.Rows[x].Cells[2].Value.ToString());
                            p = Convert.ToDouble(dgv_agregados.Rows[x].Cells[1].Value.ToString());
                            s = p * c;
                            subtotal += s;
                        }
                        else
                        {
                            break;
                        }
                    }

                    double impuesto = subtotal * 0.15;
                    double total = subtotal + impuesto;
                    int cod = 1;

                    cmd = new SqlCommand("Insert into Factura Values('" + (cbxPago.SelectedItem as dynamic).Value + "', '" + fecha + "', '" + txtDNI.Text.ToString() + "', '" + txtRTN.Text.ToString() + "', '" + impuesto + "', '" + subtotal + "', '" + total + "', '" + cod + "')", conexion.conectardb);
                    cmd.ExecuteNonQuery();
                    conexion.cerrar();

                    int factura = 0;

                    conexion.abrir();
                    cmd = new SqlCommand("Select * from Factura", conexion.conectardb);
                    string query = ("SELECT MAX(Codigo) AS Codigo FROM Factura");
                    SqlCommand com = new SqlCommand(query, conexion.conectardb);
                    SqlDataReader reg = com.ExecuteReader();
                    while (reg.Read())
                    {
                        factura = Convert.ToInt16((reg["Codigo"]));
                    }

                    conexion.cerrar();

                    // PARA TABLA DETALLE
                    string producto = "";
                    int cantidadp = 0;
                    int productocodigo = 0;

                    for (int i = 0; i < filas; i++)
                    {

                        if(dgv_agregados.Rows[i].Cells[0].Value != null && dgv_agregados.Rows[i].Cells[2].Value != null)
                        {
                            conexion.abrir();
                            producto = dgv_agregados.Rows[i].Cells[0].Value.ToString();
                            cantidadp = Convert.ToInt32(dgv_agregados.Rows[i].Cells[2].Value.ToString());
                            cmd = new SqlCommand("Select * from Productos", conexion.conectardb);
                            string consulta = ("Select * from Productos Where Nombre = '" + producto + "'");
                            SqlCommand comando = new SqlCommand(consulta, conexion.conectardb);
                            SqlDataReader registro = comando.ExecuteReader();
                            while (registro.Read())
                            {
                                productocodigo = Convert.ToInt16((registro["Codigo"]));
                            }
                            conexion.cerrar();

                            conexion.abrir();
                            cmd = new SqlCommand("Insert into Detalle Values('" + factura + "', '" + productocodigo + "', '" + cantidadp + "')", conexion.conectardb);
                            cmd.ExecuteNonQuery();
                            conexion.cerrar();
                        }
                        else
                        {
                            break;
                        }
                    }

                    MessageBox.Show("Datos ingresados con exito", "COMPLETADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos\n" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv_agregados.SelectedRows.Count > 0)
            {
                dgv_agregados.Rows.RemoveAt(dgv_agregados.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Seleccionar un codigo para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnumerof_Click(object sender, EventArgs e)
        {

        }
    }
}
