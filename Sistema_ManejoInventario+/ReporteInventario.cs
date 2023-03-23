using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

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

        private void ReporteInventario_Load(object sender, EventArgs e)
        {
            cone.abrir();
            ri.MostrarInventario(dataGridView1);
            cone.cerrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ri.Buscar(dataGridView1, this.txtBusq.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBusq.Text == String.Empty)
                {

                    MessageBox.Show("Ingrese un codigo para buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    conexion.abrir();
                    int cod = Convert.ToInt16(txtBusq.Text);
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnNormal.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            DataObject copydata = dataGridView1.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range rango = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[2, 1];
            rango.Select();

            xlsheet.PasteSpecial(rango, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                xlapp.Cells[1, i + 1] = dataGridView1.Columns[i - 1].HeaderText;
                xlapp.Cells[1, i + 1].Font.Bold = true;
                xlapp.Cells[1, i + 1].HorizontalAlignment = HorizontalAlignment.Center;
            }

            xlapp.Columns.AutoFit();
            xlapp.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            cone.abrir();
            ri.MostrarInventario(dataGridView1);
            cone.cerrar();

            txtBusq.Text = "";
        }
    }
}
