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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto.Vistas;

namespace Proyecto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string conString = "Data Source=AUDRIC-PC;Initial Catalog=ARS;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {            
            if (txtloginid.Text != "")
            {
                if (passlogin.Password != "")
                {
                    SqlConnection con = new SqlConnection(conString);
                    con.Open(); 
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        string query = "SELECT idUsuario, contrasena, tipoUsuario FROM [dbo].[Usuario] WHERE idUsuario='" 
                            + txtloginid.Text.Trim() +"' AND contrasena='" + passlogin.Password + "'";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                // Esta es la forma de operar sobre eso... 
                                string user, pass, tipo;
                                user = dr["idUsuario"].ToString();
                                pass = dr["contrasena"].ToString();
                                tipo = dr["tipoUsuario"].ToString();                               
                                if (user.Trim() == txtloginid.Text.Trim() &&
                                    pass.Trim() == passlogin.Password)
                                {
                                    //MessageBox.Show("Tipo usuario: " + tipo, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                    Dashboard nueva = new Dashboard(user, tipo);
                                    nueva.Show();
                                    con.Close();
                                    this.Close();
                                }
                            } else
                            {
                                MessageBox.Show("Información de entrada incorrecta", "Error al ingresar", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }                                                
                    } else
                    {
                        MessageBox.Show("Fallo en la conexión con al base de datos.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Falta la contraseña", "Error al Ingresar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Falta el nombre de usuario", "Error al ingresar", MessageBoxButton.OK, MessageBoxImage.Error);
         
        }
    }
}
