using MI_HOPAC.Foundation;
using MI_HOPAC.MiHomeacupService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para EditalPerfil.xaml
    /// </summary>
    public partial class InformacionPerfil : Page
    {
        string ubicacion;
        public InformacionPerfil()
        {
            InitializeComponent();
        }

        public InformacionPerfil(string ubicacionUrl)
        {
            InitializeComponent();
            ubicacion = ubicacionUrl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarDatos())
                SaveData(Int64.Parse(txtCedula.Text), ubicacion);
            else
                MessageBox.Show("Complete los datos!");
        }

        private OpenFileDialog OpenImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selecciona una nueva imagen";

            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";

            return op;  
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var dialog = OpenImage();

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;

                //Esto debera actualizarse de manera asincrona
                ProfilePhoto.ImageSource = OperacionesAsincronas.UpdateProfileImage(path);
            }
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = OpenImage();

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                var imgbrsh = new ImageBrush();

                //Esto debera actualizarse de manera asincrona
                imgbrsh.ImageSource = OperacionesAsincronas.UpdateBackgroundImage(path);

                var app = Application.Current as App;
                app.Resources["Fondo"] = imgbrsh;
            }
        }

        private void UbicacionButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = (MainMenu)Window.GetWindow(this);
            var ub = new Ubicacion();
            main.main_Frame.Navigate(ub);
        }

        private void SaveData(long cedula, string ubicacion)
        {
            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
            client.UpdateDoctres(UserControl.Fk, ubicacion, cedula);
            MessageBox.Show("Actualizados los datos");

            MainMenu main = (MainMenu)Window.GetWindow(this);
            var dash = new Dashboard();
            main.main_Frame.Navigate(dash);
        }

        public bool ValidarDatos()
        {
            return string.IsNullOrEmpty(txtCedula.Text);
        }
    }
}
