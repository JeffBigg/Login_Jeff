using Microsoft.Win32;
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

namespace login2
{
    public partial class Form1 : Form
    {
        private string cadenaConexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog=USUARIODATOS;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click_1(object sender, EventArgs e)
        {
            Registrar registerForm = new Registrar();
            registerForm.Show();
            this.Hide();
        }

        private void btnInicioSecion_Click_1(object sender, EventArgs e)
        {
            string Usuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string consulta = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND Contraseña = @Contraseña";
                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);

                int resultado = (int)comando.ExecuteScalar();

                if (resultado > 0)
                {
                    MessageBox.Show("inicio de secion exitoso");
                }
                else
                {
                    MessageBox.Show("INCORRECTO");
                }
            }

        }
    }
}
