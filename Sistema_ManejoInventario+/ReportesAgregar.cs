using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ManejoInventario_
{
    public partial class ReportesAgregar : Form
    {
        ReporteVentas rv = new ReporteVentas();
        ReporteInventario ri = new ReporteInventario();

        public ReportesAgregar()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            rv.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ri.Show();
        }
    }
}
