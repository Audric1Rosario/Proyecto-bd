﻿using System;
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
    /// Lógica de interacción para winAutorizacion.xaml
    /// </summary>
    public partial class winAutorizacion : Window
    {
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        public winAutorizacion(string typeuser)
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
            con.Close();

            if (typeuser == "usuario")
            {
                btnCancelar.IsEnabled = false;
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
