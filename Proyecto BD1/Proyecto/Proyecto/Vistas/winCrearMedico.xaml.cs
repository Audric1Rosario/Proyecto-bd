using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto.Vistas
{
    /// <summary>
    /// Lógica de interacción para winCrearMedico.xaml
    /// </summary>
    public partial class winCrearMedico : Window
    {
        string[] especialidades = { "Alergología", "Anestesiología", "Angiología", "Cardiología", "Dermatología", 
                                    "Endocrinología", "Epidemiología", "Gastroenterología", "Geriatría", "Ginecología",
                                    "Hematología", "Hepatología", "Infectología", "Neumología", "Neurología",
                                    "Nutriología", "Oftalmología", "Pediatría", "Psiquiatría", "Reumatología", 
                                    "Toxicología", "Traumatología", "Urología"};
        string[] afiliacion = { "01", "02", "03" };
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        public winCrearMedico()
        {
            InitializeComponent();
            cbxEspecialidad.ItemsSource = especialidades;
            cbxAfiliacion.ItemsSource = afiliacion;
            //cbxCentros.ItemsSource = centros();
        }
        
        /*
        string[] centros()
        {
            List<string> data = new List<string>();
            // Hacer la consulta.
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT nombre FROM CentroMedico";                                    
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(dr["nombre"].ToString().Trim());
                }                
                con.Close();
            }

            return data.ToArray();
        }*/

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            // Buscar campos vacios... 
            if (!checkWhite())
            {
                MessageBox.Show("Faltan campos por llenar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Compruevo si existe un valor del medico...
            SqlConnection con = new SqlConnection(conString);
            string queryb = "SELECT * FROM Medico WHERE codMedico = '" + txtCedula.Text + "'";
            using (SqlCommand cmd = new SqlCommand(queryb, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) // Si lee entonces existe... 
                {
                    con.Close();
                    MessageBox.Show("Ya existe el usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    init();
                    return;
                }
                
                con.Close();
            }

            
            
            // Primero inserto usuario... 
            string query = "INSERT INTO Usuario (idUsuario, contrasena, tipoUsuario) VALUES ('" +
               txtUserid.Text + "','" + txtPassword.Text + "', 'usuario');";
            using (SqlCommand cmda = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    cmda.ExecuteNonQuery();
                    con.Close();
                } catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Ya existe el usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    init();
                    return;
                }
            }
            string nombreCompleto = txtNombre.Text + " " + txtApellido.Text;
            // Despues inserto el medico... 
            string querya = "INSERT INTO Medico (codMedico, nombre, direccion, especialidad, idUsuario, numAfiliacion) VALUES " +
                "('" + txtCedula.Text + "','" + nombreCompleto + "','" + txtDireccion.Text + "','" + cbxEspecialidad.Text + "','" + txtUserid.Text
                + "','"+ cbxAfiliacion.Text + "');";
            using (SqlCommand cmda = new SqlCommand(querya, con))
            {
                try
                {
                    con.Open();
                    cmda.ExecuteNonQuery();
                    con.Close();
                } catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            MessageBox.Show("Doctor ingresado en el sistema.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            init();
        }

        private bool checkWhite()
        {
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                || txtDireccion.Text == "" || txtUserid.Text == "" || txtPassword.Text == "")
                return false;

            if (txtUserid.Text.Length < 8 || txtPassword.Text.Length < 8)
            {
                MessageBox.Show("La contraseña o el login id deben tener 8 o más caracteres.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            } 

            if (txtCedula.Text.Length < 11)
            {
                MessageBox.Show("La cédula tiene 11 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cbxAfiliacion.SelectedIndex == -1 || cbxEspecialidad.SelectedIndex == -1 /*||
                cbxCentros.SelectedIndex == -1*/)
                return false;
            return true;
        }

        private void init()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtUserid.Text = "";
            txtPassword.Text = "";

            cbxAfiliacion.SelectedIndex = -1;
            cbxEspecialidad.SelectedIndex = -1;
            return;

        }
        private void txtCedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
