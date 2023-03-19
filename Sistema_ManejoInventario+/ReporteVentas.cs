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
    }
}
