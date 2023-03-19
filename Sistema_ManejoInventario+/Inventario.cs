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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();
        SqlDataAdapter data_adapter;
        DataTable tabla_inventario;
        SqlCommand cmd;

        private void Inventario_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Llenar_Inventario();
            conexion.abrir();

            try
            {
                cmd = new SqlCommand("Select * from Categorias", conexion.conectardb);

                SqlDataReader registro = cmd.ExecuteReader();
                cmbCategoria.DisplayMember = "Text";

                while (registro.Read())
                {
                    cmbCategoria.Items.Add(new { Text = registro["Nombre"], Value = registro["Codigo"].ToString() });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dato en el ComboBox\n" + ex, "ERROR");
            }
            finally
            {
                conexion.cerrar();
            }

            conexion.abrir();
            try
            {
                cmd = new SqlCommand("Select * from Distribuidores", conexion.conectardb);

                SqlDataReader registro = cmd.ExecuteReader();
                cmbDistribuidor.DisplayMember = "Text";

                while (registro.Read())
                {
                    cmbDistribuidor.Items.Add(new { Text = registro["Nombre"], Value = registro["Codigo"].ToString() });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dato en el ComboBox\n " + ex, "ERROR");
            }
            finally
            {
                conexion.cerrar();
            }
        }

        int fila_modificada = -1;

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AgregarProducto()
        {
            try
            {
                if (txtNombre.Text == String.Empty || txtPrecioVenta.Text == String.Empty || txtStock.Text == String.Empty || txtPrecioCompra.Text == String.Empty || txtPuntoOrden.Text == String.Empty || dptFechaCompra == null || cmbCategoria == null || cmbDistribuidor == null)
                {
                    MessageBox.Show("No se pueden ingresar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    conexion.abrir();
                    string fecha = dptFechaCompra.Value.ToString("yyyy/MM/dd");
                    string nombre = txtNombre.Text.ToString();
                    double precioventa = Convert.ToDouble(txtPrecioVenta.Text.ToString());
                    double preciocompra = Convert.ToDouble(txtPrecioCompra.Text.ToString());
                    int stock = Convert.ToInt16(txtStock.Text.ToString());
                    int puntore = Convert.ToInt16(txtPuntoOrden.Text.ToString());
                    bool estado = true;

                    cmd = new SqlCommand("Insert into Productos Values('" + nombre + "', '" + stock + "', '" + precioventa + "', '" + preciocompra + "', '" + fecha + "', '" + puntore + "', '" + (cmbCategoria.SelectedItem as dynamic).Value + "', '" + (cmbDistribuidor.SelectedItem as dynamic).Value + "', '" + estado + "')", conexion.conectardb);
                    cmd.ExecuteNonQuery();
                    conexion.cerrar();
                    dataGridView1.DataSource = Llenar_Inventario();
                    MessageBox.Show("Registros agregados con exito", "COMPLETADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                limpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos\n" + ex);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (fila_modificada >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[fila_modificada];
                string codigo = fila.Cells["Codigo"].Value.ToString();
                string nombre = fila.Cells["Nombre"].Value.ToString();
                string categoria = fila.Cells["Categoria"].Value.ToString();
                int stock = Convert.ToInt32(fila.Cells["Stock"].Value);

                // Actualizar la fila en la base de datos
                conexion.abrir();
                string consulta = "UPDATE Productos SET Nombre=@Nombre, Categoria=@Categoria, Stock=@Stock WHERE Codigo=@Codigo";
                SqlCommand comando = new SqlCommand(consulta, conexion.conectardb);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Categoria", categoria);
                comando.Parameters.AddWithValue("@Stock", stock);
                comando.Parameters.AddWithValue("@Codigo", codigo);
                int filas_actualizadas = comando.ExecuteNonQuery();
                conexion.cerrar();

                if (filas_actualizadas > 0)
                {
                    MessageBox.Show("Se actualizó la fila en la base de datos.");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la fila en la base de datos.");
                }

                fila_modificada = -1;
            }
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private DataTable Llenar_Inventario()
        {
            conexion.abrir(); //apertura de la conexion
            String consulta = "SELECT Codigo, Nombre, Stock, [Precio de Venta], [Precio de Compra], [Fecha de Compra], [Punto de Reorden], Categoria, Distribuidor FROM Productos where Estado != 0";
            data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
            tabla_inventario = new DataTable();

            //llenado de la tabla con el data adpter
            data_adapter.Fill(tabla_inventario);
            conexion.cerrar();

            return tabla_inventario;
        }

        private DataTable Busqueda_Inventario(string filtro)
        {
            Console.WriteLine(filtro);
            conexion.abrir(); //apertura de la conexion
            String consulta = "select * from Productos where " + filtro.ToString(); //consulta con el filtro
            data_adapter = new SqlDataAdapter(consulta, conexion.conectardb);
            tabla_inventario = new DataTable();

            //llenado de la tabla con el data adpter
            data_adapter.Fill(tabla_inventario);
            conexion.cerrar();

            return tabla_inventario;
        }

        private void dataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_limpiar_Click_1(object sender, EventArgs e)
        {
            limpiarForm();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (fila_modificada >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[fila_modificada];
                string codigo = fila.Cells["Codigo"].Value.ToString();
                string nombre = fila.Cells["Nombre"].Value.ToString();
                string categoria = fila.Cells["Categoria"].Value.ToString();
                int stock = Convert.ToInt32(fila.Cells["Stock"].Value);

                // Actualizar la fila en la base de datos
                conexion.abrir();
                string consulta = "UPDATE Productos SET Nombre=@Nombre, Categoria=@Categoria, Stock=@Stock WHERE Codigo=@Codigo";
                SqlCommand comando = new SqlCommand(consulta, conexion.conectardb);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Categoria", categoria);
                comando.Parameters.AddWithValue("@Stock", stock);
                comando.Parameters.AddWithValue("@Codigo", codigo);
                int filas_actualizadas = comando.ExecuteNonQuery();
                conexion.cerrar();

                if (filas_actualizadas > 0)
                {
                    MessageBox.Show("Se actualizó la fila en la base de datos.");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la fila en la base de datos.");
                }

                fila_modificada = -1;
            }
            else
            {
                MessageBox.Show("Realice cambios para actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            limpiarForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filtro;

            if (comboBox1.Text == String.Empty)
            {
                MessageBox.Show("Escoja el filtro para realizar la busqueda correctamente", "Error de busqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                comboBox1.DroppedDown = true;
            }
            else if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Escriba algo para realizar la busqueda correctamente", "Error de busqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                btnActualizar.Enabled = false;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                if (comboBox1.Text == "Codigo")
                {
                    filtro = comboBox1.Text + " = " + textBox1.Text; //filtro para el codigo
                }
                else
                {
                    filtro = comboBox1.Text + " LIKE '%" + textBox1.Text + "%'"; //filtro para categoria y nombre
                }
                dataGridView1.DataSource = Busqueda_Inventario(filtro);
                textBox1.Focus();
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            conexion.abrir();
            try
            {
                if (textBox1.Text != String.Empty)
                {

                    DialogResult d = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (d == DialogResult.Yes)
                    {

                        string borrar2 = "UPDATE Productos SET Estado = 0 WHERE Codigo = @Codigo;";
                        using (SqlCommand command = new SqlCommand(borrar2, conexion.conectardb))
                        {
                            command.Parameters.AddWithValue("@Codigo", textBox1.Text);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Registro eliminado con exito", "COMPLETADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = Llenar_Inventario();
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
            textBox1.Clear();
            textBox1.Enabled = true;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Enabled = false;
        }

        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            fila_modificada = e.RowIndex;
        }

        private void limpiarForm()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }

                cmbCategoria.SelectedIndex = -1;
                cmbDistribuidor.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
            }
            textBox1.Enabled = true;
            dataGridView1.DataSource = Llenar_Inventario();
            btnActualizar.Enabled = true;
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
