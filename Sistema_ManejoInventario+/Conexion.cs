using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema_ManejoInventario_
{
    public class Conexion
    {
        string cadena = "Data source=LAPTOP-3KI7LCMK;Initial Catalog=RaxelDB;Integrated Security=True";
        public SqlConnection conectardb = new SqlConnection();

        public Conexion()
        {
            conectardb.ConnectionString = cadena; //especificacion del origen de datos.
        }

        public void abrir()
        {
            try
            {
                conectardb.Open();
                Console.WriteLine("Conexion abierta!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al abrir la Base de Datos"+ex.Message);
            }
        }

        public void cerrar()
        {
            conectardb.Close();
        }


    }
}
