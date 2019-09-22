using System;
using System.Collections.Generic;
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
using MI_HOPAC.MiHomeacupService;

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            profile_Name.Visibility = Visibility.Collapsed;
            main_Frame.Content = new Dashboard();

            //var client = new MainWebServiceSoapClient();
            //List<DoctoresModel> misDoctores = new List<DoctoresModel>(client.getDoctores(3));
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            profile_Name.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            profile_Name.Visibility = Visibility.Collapsed;
        }

        private void Side_Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(side_Menu.SelectedIndex)
            {
                case 0:
                    main_Frame.Content = new Dashboard();
                    title.Text = "Inicio";
                    break;
                case 1:
                    main_Frame.Content = new Agenda();
                    title.Text = "Calendario";
                    break;
                case 2:
                    title.Text = "Expedientes";
                    //TO DO: ver mas a detalle la paginacion de las carpetas de expedientes
                    break;
                case 3:
                    main_Frame.Content = new Eventos();
                    title.Text = "Eventos";
                    break;
                case 4:
                    main_Frame.Content = new NotasInformativas();
                    title.Text = "Notas informativas";
                    break;
                case 5:
                    main_Frame.Content = new ForoPrivado();
                    title.Text = "Foro privado";
                    break;
                case 6:
                    main_Frame.Content = new Inventario();
                    title.Text = "Inventario";
                    break;
            }
        }
    }
}
