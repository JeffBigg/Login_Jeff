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
    public partial class Registrar : Form
    {
        private string cadenaConexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog=USUARIODATOS;Integrated Security=True";

        public Registrar()
        {
            InitializeComponent();
        }
        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEdad.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0)
            {
                MessageBox.Show("La edad debe ser un número positivo.");
                return;
            }


            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string contraseña = txtContraseña.Text;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();


                string query = "INSERT INTO Usuarios (NombreUsuario, NombreCompleto, Edad, Email, Contraseña) VALUES (@Nombre, @Correo, @Edad, @Email, @Contraseña)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Edad", edad);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el registro.");
                    }
                }


            }
        }
    }
}
