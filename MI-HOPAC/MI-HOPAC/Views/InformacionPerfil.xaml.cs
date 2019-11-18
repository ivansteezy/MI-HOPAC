using MI_HOPAC.Foundation;
using MI_HOPAC.MiHomeacupService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MI_HOPAC.Views
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

        private void HorarioButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new HorarioDialog();
            var tuplelist = new TupleList<DateTime?, DateTime?, int, int>();

            var client = new MainWebServiceSoapClient();

            if (dlg.ShowDialog() == true)
            {
                var diasLaborales = dlg.MapaDias;
                var res = diasLaborales.Where(pair => pair.Value == true).Select(pair => pair.Key);
                
                foreach(var item in res)
                {
                    var horaInicio = dlg.MapaHoraInicio.Where(pair => pair.Key == item).Select(pair => pair.Value).First();
                    var horaFinal = dlg.MapaHoraFinal.Where(pair => pair.Key == item).Select(pair => pair.Value).First();
                    tuplelist.Add(horaInicio, horaFinal, item, UserControl.Pk);
                }

                //Eliminamos todos los dias antes insertar los nuevos
                client.LimpiarHorario(UserControl.Pk);

                foreach(var item in tuplelist)
                {
                    client.InsertarHorarios(item.Item1.Value.TimeOfDay.ToString(), item.Item2.Value.TimeOfDay.ToString(), item.Item3, item.Item4);
                }
                MessageBox.Show("Datos insertados correctamente!");
            }   
        }

        private void TxtCedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

    public class TupleList<T1, T2, T3, T4> : List<Tuple<T1, T2, T3, T4>>
    {
        public void Add(T1 horaInicio, T2 horaFinal, T3 dia, T4 pkDoctor)
        {
            Add(new Tuple<T1, T2, T3, T4>(horaInicio, horaFinal, dia, pkDoctor));
        }
    }
}
