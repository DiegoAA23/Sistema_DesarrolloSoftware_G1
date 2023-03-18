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
    public partial class ReporteVentas : Form
    {
        clsReporteVentas rv = new clsReporteVentas();
        Conexion cone = new Conexion();

        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            cone.abrir();
            rv.MostrarInventarioVentas(dataGridView1);
        }
    }
}
