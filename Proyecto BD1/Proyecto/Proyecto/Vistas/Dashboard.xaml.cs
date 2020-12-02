using System.Windows;
using System.Windows.Media;

namespace Proyecto.Vistas
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        string user;
        string type;
        public Dashboard(string username, string typeuser)
        {
            InitializeComponent();
            basic = (Color)ColorConverter.ConvertFromString(basicColor); 
            active = (Color)ColorConverter.ConvertFromString(activeColor);
            user = username;
            type = typeuser;

            if (typeuser == "usuario")
            {                            
                // No puede usar.
                btnCrearCentro.IsEnabled = false;
                btnCrearMedico.IsEnabled = false;
            } else if (typeuser == "administrador")
            {
                btnPerfil.IsEnabled = false;
                btnCrearConsulta.IsEnabled = false;
            }
        }

        #region Menu
        // Colores de los botones. 
        // Basico: #FFDDDDDD
        // Activo: #FFA0F1B6
        const string basicColor = "#FFDDDDDD";
        const string activeColor = "#FFA0F1B6";
        Color basic;
        Color active;
        private void btnPacientes_Click(object sender, RoutedEventArgs e)
        {
            if (btnPacientes.Background.ToString() == basicColor)
            {
                selectMode(1, true);
                btnPacientes.Background = new SolidColorBrush(active);
            } else
            {
                selectMode(1, false);
                btnPacientes.Background = new SolidColorBrush(basic);
            }           
        }

        private void btnMedicos_Click(object sender, RoutedEventArgs e)
        {
            if (btnMedicos.Background.ToString() == basicColor)
            {
                selectMode(2, true);
                btnMedicos.Background = new SolidColorBrush(active);
            }
            else
            {
                selectMode(1, false);
                btnMedicos.Background = new SolidColorBrush(basic);
            }
        }

        private void btnSeguros_Click(object sender, RoutedEventArgs e)
        {
            if (btnSeguros.Background.ToString() == basicColor)
            {
                selectMode(3, true);
                btnSeguros.Background = new SolidColorBrush(active);
            }
            else
            {
                selectMode(1, false);
                btnSeguros.Background = new SolidColorBrush(basic);
            }
        }

        private void btnAutorizaciones_Click(object sender, RoutedEventArgs e)
        {
            if (btnAutorizaciones.Background.ToString() == basicColor)
            {
                selectMode(4, true);
                btnAutorizaciones.Background = new SolidColorBrush(active);
            }
            else
            {
                selectMode(1, false);
                btnAutorizaciones.Background = new SolidColorBrush(basic);
            }
        }

        private void btnConsultas_Click(object sender, RoutedEventArgs e)
        {
            if (btnConsultas.Background.ToString() == basicColor)
            {
                selectMode(5, true);
                btnConsultas.Background = new SolidColorBrush(active);
            }
            else
            {
                selectMode(1, false);
                btnConsultas.Background = new SolidColorBrush(basic);
            }
        }

        // Esto es para poder seleccionar lo que quieres ver. 
        /*
         1. Pacientes.
         2. Médicos.
         3. Centros Medicos.
         4. Autorizaciones.
         5. Consultas
         */
        private void selectMode(int numberGrid, bool select)
        {
            // Activar / Desactivar
            if (select)
            {
                gridPaciente.IsEnabled = numberGrid == 1;
                gridDoctores.IsEnabled = numberGrid == 2;
                gridCentros.IsEnabled = numberGrid == 3;
                gridAutorizaciones.IsEnabled = numberGrid == 4;
                gridConsultas.IsEnabled = numberGrid == 5;
                // Mostrar / No mostrar.
                gridPaciente.Visibility = numberGrid == 1 ? Visibility.Visible : Visibility.Hidden;
                gridDoctores.Visibility = numberGrid == 2 ? Visibility.Visible : Visibility.Hidden;
                gridCentros.Visibility = numberGrid == 3 ? Visibility.Visible : Visibility.Hidden;
                gridAutorizaciones.Visibility = numberGrid == 4 ? Visibility.Visible : Visibility.Hidden;
                gridConsultas.Visibility = numberGrid == 5 ? Visibility.Visible : Visibility.Hidden;
                // Colores...
                switch (numberGrid)
                {
                    case 1:
                        btnPacientes.Background = new SolidColorBrush(active);
                        btnMedicos.Background = new SolidColorBrush(basic);
                        btnSeguros.Background = new SolidColorBrush(basic);
                        btnAutorizaciones.Background = new SolidColorBrush(basic);
                        btnConsultas.Background = new SolidColorBrush(basic);
                        break;

                    case 2:
                        btnPacientes.Background = new SolidColorBrush(basic);
                        btnMedicos.Background = new SolidColorBrush(active);
                        btnSeguros.Background = new SolidColorBrush(basic);
                        btnAutorizaciones.Background = new SolidColorBrush(basic);
                        btnConsultas.Background = new SolidColorBrush(basic);
                        break;

                    case 3:
                        btnPacientes.Background = new SolidColorBrush(basic);
                        btnMedicos.Background = new SolidColorBrush(basic);
                        btnSeguros.Background = new SolidColorBrush(active);
                        btnAutorizaciones.Background = new SolidColorBrush(basic);
                        btnConsultas.Background = new SolidColorBrush(basic);
                        break;

                    case 4:
                        btnPacientes.Background = new SolidColorBrush(basic);
                        btnMedicos.Background = new SolidColorBrush(basic);
                        btnSeguros.Background = new SolidColorBrush(basic);
                        btnAutorizaciones.Background = new SolidColorBrush(active);
                        btnConsultas.Background = new SolidColorBrush(basic);
                        break;

                    case 5:
                        btnPacientes.Background = new SolidColorBrush(basic);
                        btnMedicos.Background = new SolidColorBrush(basic);
                        btnSeguros.Background = new SolidColorBrush(basic);
                        btnAutorizaciones.Background = new SolidColorBrush(basic);
                        btnConsultas.Background = new SolidColorBrush(active);
                        break;

                    default:
                        btnPacientes.Background = new SolidColorBrush(basic);
                        btnMedicos.Background = new SolidColorBrush(basic);
                        btnSeguros.Background = new SolidColorBrush(basic);
                        btnAutorizaciones.Background = new SolidColorBrush(basic);
                        btnConsultas.Background = new SolidColorBrush(basic);
                        break;
                }
            } else
            {
                gridPaciente.IsEnabled = false;
                gridDoctores.IsEnabled = false;
                gridCentros.IsEnabled = false;
                gridAutorizaciones.IsEnabled = false;
                gridConsultas.IsEnabled = false;
                // Mostrar / No mostrar.
                gridPaciente.Visibility = Visibility.Hidden;
                gridDoctores.Visibility = Visibility.Hidden;
                gridCentros.Visibility = Visibility.Hidden;
                gridAutorizaciones.Visibility = Visibility.Hidden;
                gridConsultas.Visibility = Visibility.Hidden;

                // Desactivar colores
                btnPacientes.Background = new SolidColorBrush(basic);
                btnMedicos.Background = new SolidColorBrush(basic);
                btnSeguros.Background = new SolidColorBrush(basic);
                btnAutorizaciones.Background = new SolidColorBrush(basic);
                btnConsultas.Background = new SolidColorBrush(basic);
            }
        }
        #endregion

        #region Botones_Secciones

        // Pacientes
        private void btnCrearPaciente_Click(object sender, RoutedEventArgs e)
        {
            winCrearPaciente nuevo = new winCrearPaciente();
            nuevo.Owner = this;           
            nuevo.ShowDialog(); // ShowDialog: Modal ON
        }

        private void btnVerPacientes_Click(object sender, RoutedEventArgs e)
        {
            winPaciente nuevo = new winPaciente();
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        // Médicos
        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {
            winPerfilMedico nuevo = new winPerfilMedico(user, type);
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        private void btnListaMedicos_Click(object sender, RoutedEventArgs e)
        {
            winMedico nuevo = new winMedico();
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        
        private void btnCrearMedico_Click(object sender, RoutedEventArgs e)
        {
            winCrearMedico nuevo = new winCrearMedico();
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        // Centros
        private void btnVerCentros_Click(object sender, RoutedEventArgs e)
        {
            winCentroSalud nuevo = new winCentroSalud();
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        private void btnCrearCentro_Click(object sender, RoutedEventArgs e)
        {
            winCrearCentro nuevo = new winCrearCentro();
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        // Autorizaciones
        private void btnCrearAuto_Click(object sender, RoutedEventArgs e)
        {
            winCrearAuto nuevo = new winCrearAuto(type);
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        private void btnListaAuto_Click(object sender, RoutedEventArgs e)
        {
            winAutorizacion nuevo = new winAutorizacion(type);
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        // Consultas
        private void btnCrearConsulta_Click(object sender, RoutedEventArgs e)
        {
            winCrearConsulta nuevo = new winCrearConsulta(user);
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        private void btnGenerarHistorial_Click(object sender, RoutedEventArgs e)
        {
            winHistorial nuevo = new winHistorial();
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        #endregion
    }
}
