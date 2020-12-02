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
    /// Lógica de interacción para winCrearConsulta.xaml
    /// </summary>
    public partial class winCrearConsulta : Window
    {
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        string user;
        public winCrearConsulta(string userid)
        {
            user = userid;
            InitializeComponent();
            txtFecha.Text = DateTime.Now.Date.ToString();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            // Resetear al empezar a buscar
            lstPacientes.SelectedIndex = -1;
            lstPacientes.ItemsSource = null;
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Por favor, busque el cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } else
            {
                SqlConnection con = new SqlConnection(conString);
                // Tomar los datos y agregarlos a una lista.
                List<string> data = new List<string>();
                SqlCommand cmd = new SqlCommand("SELECT codPaciente, nombre FROM Paciente WHERE " +
                    "codPaciente LIKE '%" + txtBuscar.Text + "%'", con);

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(dr["codPaciente"].ToString() + " " + dr["nombre"].ToString());
                    }
                    con.Close();

                } catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                lstPacientes.ItemsSource = data.ToArray();
            }
        }

        private void txtBuscar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
               e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (lstPacientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, busque el cliente y seleccionelo en la lista antes de pulsar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string codPaciente = lstPacientes.SelectedItem.ToString().Split()[0].Trim();
            MessageBox.Show(codPaciente);

            SqlConnection con = new SqlConnection(conString);
            // Tomar los datos y agregarlos a una lista.
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente WHERE " +
                "codPaciente = '" + codPaciente + "'", con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Llenar los datos... 
                    txtCedulaPaciente.Text = codPaciente;
                    txtNombrePaciente.Text = dr["nombre"].ToString().Trim();
                    txtTipoSangre.Text = dr["tipoSangre"].ToString().Trim();
                    txtNacimPaciente.Text = dr["fechaNacimiento"].ToString().Trim();
                    txtAfiliacion.Text = dr["numAfiliacion"].ToString().Trim();
                    txtCobertura.Text = dr["monto"].ToString().Trim();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                init();
                return;
            } 
            
        }

        

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (!checkWhite())
            {
                MessageBox.Show("Faltan campos por llenar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                //init();
                return;
            }



           SqlConnection con = new SqlConnection(conString);

            string queryb = "SELECT COUNT(*) AS Suma FROM Procedimiento";
            int count = 0;
            using (SqlCommand cmd = new SqlCommand(queryb, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    count = int.Parse(dr["Suma"].ToString().Trim());
                con.Close();
            }

            string queryc = "SELECT codMedico FROM Medico WHERE idUsuario = '" + user + "'";
            string codMedico = "";
            using (SqlCommand cmd = new SqlCommand(queryc, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    codMedico = dr["codMedico"].ToString().Trim();
                con.Close();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Procedimiento (codProcedimiento, tipoProcedimiento, medicamento, monto, cobertura, padecimiento," +
                    "descripcion, fecha, codMedico) VALUES (" +
                "'" + count +"PRO','"+ txtTipoConsulta.Text+"','"+txtMedicamento.Text+"','"+
                txtCobertura.Text+"','"+ txtCobertura.Text + "','"+txtPadecimiento.Text+"','"+
                txtDescripcion.Text+"','"+txtFecha.Text+"','" + codMedico + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            init();
        }

        private bool checkWhite()
        {
            if (txtNombrePaciente.Text == "" || txtCobertura.Text == "" ||
                txtCedulaPaciente.Text == "" || txtTipoSangre.Text == "" ||
                txtNacimPaciente.Text == "" || txtAfiliacion.Text == "" || txtTipoConsulta.Text == "" ||
                txtPadecimiento.Text == "" || txtMedicamento.Text == "" || txtDescripcion.Text == "")
            {
                return false;
            }

            return true;
        }

        private void init()
        {
            // Devuelve todo a su estado inicial
            txtBuscar.Text = "";
            txtNombrePaciente.Text = "";
            txtCobertura.Text = "";
            txtCedulaPaciente.Text = "";
            txtTipoSangre.Text = "";
            //txtFecha.Text = "";
            txtNacimPaciente.Text = "";
            txtAfiliacion.Text = "";
            txtTipoConsulta.Text = "";
            txtPadecimiento.Text = "";
            txtMedicamento.Text = "";
            txtDescripcion.Text = "";

            lstPacientes.ItemsSource = null;
            return;
        }
    }
}
