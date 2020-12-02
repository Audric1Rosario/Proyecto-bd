using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para winPaciente.xaml
    /// </summary>
    public partial class winPaciente : Window
    {
        string[] opciones = { "Búsqueda normal", "Autorizaciones", "Riesgo" };
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";

        public winPaciente()
        {
            InitializeComponent();
            cbxOpcion.ItemsSource = opciones;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            if (cbxOpcion.SelectedIndex != -1)
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                switch (cbxOpcion.Text.Trim())
                {
                    case "Búsqueda normal":
                        btnSeleccionar.IsEnabled = true;
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente", con);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGrid.ItemsSource = table.DefaultView;
                        break;
                 
                    case "Autorizaciones":
                        btnSeleccionar.IsEnabled = false;
                        SqlCommand cmda = new SqlCommand("SELECT Paciente.codPaciente, COUNT(Procedimiento.monto) AS 'Monto Consumido'" +
                            "FROM (Paciente" +
                            "INNER JOIN Autorizacion" +
                            "ON Paciente.codPaciente = Autorizacion.codAutorizacion" +
                            "INNER JOIN Procedimiento" +
                            "ON Autorizacion.codProcedimiento = Procedimiento.codProcedimiento)" +
                            "WHERE Autorizacion.fecha > @FechaInicio and Autorizacion.fecha < @FechaFin and Procedimiento.descripcion LIKE '%alto riesgo%'" +
                            "GROUP BY Paciente.codPaciente", con);
                        SqlDataAdapter adaptera = new SqlDataAdapter();
                        adaptera.SelectCommand = cmda;
                        DataTable tablea = new DataTable();
                        adaptera.Fill(tablea);
                        dataGrid.ItemsSource = tablea.DefaultView;
                        break;

                    case "Riesgo":
                        btnSeleccionar.IsEnabled = false;
                        SqlCommand cmdb = new SqlCommand("SELECT * FROM Paciente", con);
                        SqlDataAdapter adapterb = new SqlDataAdapter();
                        adapterb.SelectCommand = cmdb;
                        DataTable tableb = new DataTable();
                        adapterb.Fill(tableb);
                        dataGrid.ItemsSource = tableb.DefaultView;
                        break;    
                        
                }
                con.Close();
            }
        }
    }
}
