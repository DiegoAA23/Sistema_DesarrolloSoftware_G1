using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ManejoInventario_
{
    public partial class ReporteVentas : Form
    {
        
        Conexion conexion = new Conexion();

        public ReporteVentas()
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

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            clsReporteVentas rv = new clsReporteVentas();
            rv.MostrarInventarioVentas(dataGridView1);
            conexion.cerrar();
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

        private void BarraTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.abrir();
            string fecha = dtpFiltro.Value.ToString("yyyy/MM/dd");
            clsReporteVentas rv = new clsReporteVentas();
            rv.FiltroReporteVentas(dataGridView1, fecha);
            conexion.cerrar();
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
                xlapp.Cells[1, i+1] = dataGridView1.Columns[i - 1].HeaderText;
                xlapp.Cells[1, i+1].Font.Bold = true;
                xlapp.Cells[1, i+1].HorizontalAlignment = HorizontalAlignment.Center;
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
            conexion.abrir();
            clsReporteVentas rv = new clsReporteVentas();
            rv.MostrarInventarioVentas(dataGridView1);
            conexion.cerrar();
            dtpFiltro.Value = DateTime.Now;
        }
    }
}
