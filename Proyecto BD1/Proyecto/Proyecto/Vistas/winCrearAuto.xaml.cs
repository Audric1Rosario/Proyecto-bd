using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para winCrearAuto.xaml
    /// </summary>
    /// 
       
    public partial class winCrearAuto : Window
    {
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        public winCrearAuto(string typeuser)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Procedimiento", con);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
            txtFecha.Text = DateTime.Now.Date.ToString();
            con.Close();
            
            List<string> center = new List<string>();
            SqlCommand cmda = new SqlCommand("SELECT * FROM CentroMedico", con);
            con.Open();
            SqlDataReader dra = cmda.ExecuteReader();
            while (dra.Read())
            {
                center.Add(dra["codCentroMedico"].ToString().Trim());
            }
            cbxCentro.ItemsSource = center.ToArray();
            con.Close();

            List<string> medicos = new List<string>();
            SqlCommand cmdb = new SqlCommand("SELECT * FROM Medico", con);
            con.Open();
            SqlDataReader drb = cmdb.ExecuteReader();
            while (drb.Read())
            {
                medicos.Add(drb["codMedico"].ToString().Trim());
            }
            cbxMedico.ItemsSource = medicos.ToArray();
            con.Close();

            List<string> pacientes = new List<string>();
            SqlCommand cmdc = new SqlCommand("SELECT * FROM Paciente", con);
            con.Open();
            SqlDataReader drc = cmdc.ExecuteReader();
            while (drc.Read())
            {
                pacientes.Add(drc["codPaciente"].ToString().Trim());
            }
            cbxPaciente.ItemsSource = pacientes.ToArray();
            con.Close();

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)dataGrid.SelectedItems[0];

                // Luego puedes revisar: 
                txtCobertura.Text = row["Cobertura"].ToString().Trim();
                txtTipoConsulta.Text = row["tipoProcedimiento"].ToString().Trim();
                txtDescripcion.Text = row["descripcion"].ToString().Trim();
                txtMedicamento.Text = row["medicamento"].ToString().Trim();
                cbxProcedimiento.Text = row["codProcedimiento"].ToString().Trim();
            }
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxProcedimiento.Text != "" && cbxCentro.Text != "" &&
                cbxMedico.Text != "" && cbxPaciente.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);

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

                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Autorizacion (codAutorizacion, fecha, codCentroMedico, codMedico, codProcedimiento, codPaciente) VALUES" +
                    "('" + count + "AU','" + txtFecha.Text + "','" + cbxCentro.Text + "','" + cbxMedico.Text + "','" + cbxProcedimiento.Text + "','" + cbxPaciente.Text + "');", con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                init();
            }
            else
            {
                MessageBox.Show("Falta llenar un campo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void init()
        {
            txtCobertura.Text ="";
            txtTipoConsulta.Text = "";
            txtDescripcion.Text = "";
            txtMedicamento.Text = "";
            cbxProcedimiento.Text = "";

            cbxCentro.Text = "";
            cbxPaciente.Text = "";
            cbxMedico.Text = "";
            return;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
