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
    /// Lógica de interacción para winCrearCentro.xaml
    /// </summary>
    public partial class winCrearCentro : Window
    {
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        string[] afiliacion = { "01", "02", "03" };
        public winCrearCentro()
        {
            InitializeComponent();
            cbxAfiliacion.ItemsSource = afiliacion;
            cargarProvincias();
        }

        // Para cargar las provincias... 
        private void cargarProvincias()
        {
            List<string> data = new List<string>(); 
            string query = "SELECT codProvincia, nombre FROM Provincia";
            SqlConnection con = new SqlConnection(conString);
            using (SqlCommand cmd = new SqlCommand(query, con)) {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    while (dr.Read())
                    {
                        data.Add(dr["nombre"].ToString().Trim());
                    }
                } else
                {
                    MessageBox.Show("No existen provincias en la base de datos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();
            }
            cbxProvincia.ItemsSource = data.ToArray();
            
            return;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            // Para verificar que todo este lleno.
            if (!checkWhite())
            {
                MessageBox.Show("Faltan campos por llenar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try {
                string querya = "SELECT codMunicipio FROM Municipio WHERE nombre = '" + lstMunicipio.SelectedItem.ToString() + "'";
                string d = "";
                SqlConnection con = new SqlConnection(conString);
                using (SqlCommand cmd = new SqlCommand(querya, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        d = dr["codMunicipio"].ToString().Trim();                    }
                    else
                    {
                        MessageBox.Show("Error de municipio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    con.Close();
                }

                if (d == "")
                {
                    MessageBox.Show("No existen provincias en la base de datos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    init();
                    return;
                }

                string queryb = "SELECT COUNT(*) AS Suma FROM CentroMedico";
                int count = 0;
                using (SqlCommand cmd = new SqlCommand(queryb, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        count = int.Parse(dr["Suma"].ToString().Trim());
                    con.Close();
                }

                // Esto va de ultimo... 
                // Hacer insert.
                string query = "INSERT INTO CentroMedico (codCentroMedico, nombre, codMunicipio, numAfiliacion) VALUES " +
                    "('" + count + "CNT','" + txtNombre.Text + "','" + d + "','" + cbxAfiliacion.Text + "');";
                using (SqlCommand cmda = new SqlCommand(query, con))
                {
                    con.Open();
                    cmda.ExecuteNonQuery();
                    con.Close();
                }

                //string query = "INSERT INTO "
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            MessageBox.Show("Se ha registrado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            init();
            return;
        }
        // Funcion para revisar que no falta nada.
        private bool checkWhite()
        {
            if (txtNombre.Text == "")
                return false;

            if (cbxProvincia.SelectedIndex == -1 || cbxAfiliacion.SelectedIndex == -1)
                return false;

            if (lstMunicipio.SelectedIndex == -1)
                return false;

            if (txtPlazas.Text == "")
                return false;

            return true;
        }

        private void init()
        {
            txtNombre.Text = "";
            cbxProvincia.SelectedIndex = -1;
            lstMunicipio.SelectedIndex = -1;
            lstMunicipio.ItemsSource = null;            
            txtPlazas.Text = "";
            cbxAfiliacion.SelectedIndex = -1;
            return;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Hacer join para indice seleccionado... 
            if (cbxProvincia.SelectedIndex != -1)
            {
                string nombreProvincia = cbxProvincia.Text;
                string query = "SELECT Municipio.nombre AS munNombre FROM Provincia INNER JOIN Municipio " +
                    "ON Provincia.CodProvincia = Municipio.CodProvincia WHERE " +
                    "'" + nombreProvincia + "' = Provincia.nombre";

                try
                {
                    List<string> data = new List<string>();
                    SqlConnection con = new SqlConnection(conString);
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            while (dr.Read())
                            {
                                data.Add(dr["munNombre"].ToString().Trim());
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existen provincias en la base de datos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        con.Close();
                    }
                    lstMunicipio.ItemsSource = data.ToArray();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            } else
            {
                MessageBox.Show("No se ha escogido una provincia.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void txtPlazas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
