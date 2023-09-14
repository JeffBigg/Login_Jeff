using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Text;

namespace WindowsFormsApp1
{
    public partial class dash : Form
    {
        private string cadenaConexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog=USUARIODATOS;Integrated Security=True";
        public dash()

        {
            InitializeComponent();
            CargarDatos();

        }

       
        private void CargarDatos()
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Usuarios";
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                    {
                        DataSet dataSet = new DataSet();
                        adaptador.Fill(dataSet, "Usuarios");
                        dataGridView1.DataSource = dataSet.Tables["Usuarios"];

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
    }
}
