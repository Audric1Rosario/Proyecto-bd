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
    /// Lógica de interacción para winCrearPaciente.xaml
    /// </summary>
    public partial class winCrearPaciente : Window
    {
        string[] estado = { "Soltero", "Casado" };
        string[] nacionalidad = { "DOM", "USA", "COL", "CHN", "CRI", "CUB"};
        string[] sexo = { "M", "F" };
        string[] tipoSangre = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        string[] afiliacion = { "01", "02", "03" };
        public winCrearPaciente()
        {
            InitializeComponent();
            // Crear todos los itenes del combo box
            cbxEstado.ItemsSource = estado;
            cbxNacionalidad.ItemsSource = nacionalidad;
            cbxSexo.ItemsSource = sexo;
            cbxTipoSangre.ItemsSource = tipoSangre;
            cbxAfiliacion.ItemsSource = afiliacion;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (!checkData())
            {
                MessageBox.Show("Faltó llenar un campo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
                
        
            // Empezar a validar que todos los datos sean de acuerdo a lo que pide la base de datos... 
            if (txtCedula.Text.Length < 11)
            {
                MessageBox.Show("Una cédula debe tener 11 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
                

            if (txtTelefono.Text.Length < 10)
            {
                MessageBox.Show("Un número de teléfono tiene 10 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Empezar procedimiento para insertar paciente...

            try
            {
                string nombreCompleto = txtNombre.Text + " " + txtApellido.Text;
                SqlConnection conn = new SqlConnection(conString);

                string query = "INSERT INTO Paciente (codPaciente, nombre, direccion, sexo, nacionalidad, fechaNacimiento, telefono, tipoSangre, estadoCivil, numAfiliacion, tipoPlan, monto) " +
                    "VALUES ('"+txtCedula.Text+"','" + nombreCompleto + "','" + txtDireccion.Text + "','" + cbxSexo.Text + "','" + cbxNacionalidad.Text + "', GETDATE(),'" + txtTelefono.Text + "','"
                    + cbxTipoSangre.Text + "','" + cbxEstado.Text + "','" + cbxAfiliacion.Text +"','" + txtPlan.Text + "','" + txtCobertura.Text+ "');";

                using (SqlCommand cmda = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmda.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
              
            }
            MessageBox.Show("Se ha registrado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            init();
            return;
        }


        // verificar que este todo lleno... 
        private bool checkData()
        {
            // Verificar los boxes
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" ||
                txtDireccion.Text == "" || txtPlan.Text == "" || txtCobertura.Text == "" ||
                txtTelefono.Text == "")
                return false;

            // Verificar index de los combo box... 
            if (cbxSexo.SelectedIndex == -1 || cbxNacionalidad.SelectedIndex == -1 ||
                cbxEstado.SelectedIndex == -1 || cbxTipoSangre.SelectedIndex == -1 ||
                cbxAfiliacion.SelectedIndex == -1)
                return false;

            // Calendario vacio...
            if (calFecha.SelectedDate.ToString().Length == 0)
                return false;
           
            return true;
        }

        private void init()
        {
            // Combo
            cbxAfiliacion.SelectedIndex = -1;
            cbxEstado.SelectedIndex = -1;
            cbxNacionalidad.SelectedIndex = -1;
            cbxSexo.SelectedIndex = -1;
            cbxTipoSangre.SelectedIndex = -1;
            // TextBox 
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCobertura.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtPlan.Text = "";
            txtTelefono.Text = "";
            // calendario
            calFecha.SelectedDate = null;

            return;
        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            return;
        }

        private void txtCedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
