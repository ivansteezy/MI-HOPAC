using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using QRCoder;
using MI_HOPAC.MiHomeacupService;

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para NuevoEvento.xaml
    /// </summary>
    public partial class NuevoEvento : Page
    {
        public NuevoEvento()
        {
            InitializeComponent();
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            //Verificamos que los datos esten completos
            if (ValidarInfo())
            {
                string guia = txt_GuiaEvento.Text;
                string nombre = txt_Nombre.Text;
                string ubicacion = txt_Ubicacion.Text;
                string hora = txt_HoraEvento.SelectedTime.ToString().Substring(txt_HoraEvento.SelectedTime.ToString().IndexOf(' ') + 1);
                string fecha = txt_FechaEvento.SelectedDate.ToString().Substring(0, txt_FechaEvento.SelectedDate.ToString().IndexOf(' '));

                var date = DateTime.Parse(fecha + " " + hora);

                MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
                client.InsertEventos(nombre, date, ubicacion, guia, UserControl.Pk); //Los insertamos a la base de datos
                var modelo = client.GetEventosByName(nombre).ToArray(); //Hacemos una consulta de lo que acabamos de insertar

                QR.Source = Foundation.EventosSection.GenerarQR(modelo.First()); //Generamos el QR
            }
            else
                MessageBox.Show("Debes completar todos los campos!");
        }

        //Funcion para lavidar que los datos esten completos
        public bool ValidarInfo()
        {
            if (string.IsNullOrEmpty(txt_GuiaEvento.Text) || string.IsNullOrEmpty(txt_Nombre.Text)     ||
                string.IsNullOrEmpty(txt_Ubicacion.Text)  || string.IsNullOrEmpty(txt_HoraEvento.Text) ||
                string.IsNullOrEmpty(txt_FechaEvento.Text))
                return false;
            else
                return true;
        }
    }
}
