using System;
using System.Collections.Generic;
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
using Proyecto;

namespace Proyecto.Vistas
{
    /// <summary>
    /// Lógica de interacción para winPerfilMedico.xaml
    /// </summary>
    public partial class winPerfilMedico : Window
    {
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        public winPerfilMedico(string user, string type)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(conString);

            try
            {
                
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Medico WHERE idUsuario = '" + user + "'", con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtNombre.Text = dr["nombre"].ToString();
                        txtCedula.Text = dr["codMedico"].ToString();
                        txtEspecialidad.Text = dr["especialidad"].ToString();
                        txtUserid.Text = user;
                        txtAfiliacion.Text = dr["numAfiliacion"].ToString();
                    } else
                    {
                        MessageBox.Show("Error al leer perfil.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        con.Close();
                        this.Close();
                    }
                    con.Close();
                }
                

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

                throw;
            }
        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
