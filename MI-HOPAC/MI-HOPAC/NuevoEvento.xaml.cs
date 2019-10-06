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
            ///TODO Ver que generar en el qr, si en base a nombres o a pk para que la aplicacion pueda hacer la consulta.
            //Esto ya inserta en la base de datos
            string guia = txt_GuiaEvento.Text;
            string nombre = txt_Nombre.Text;
            string ubicacion = txt_Ubicacion.Text;
            string hora = txt_HoraEvento.SelectedTime.ToString().Substring(txt_HoraEvento.SelectedTime.ToString().IndexOf(' ') + 1);
            string fecha = txt_FechaEvento.SelectedDate.ToString().Substring(0, txt_FechaEvento.SelectedDate.ToString().IndexOf(' '));

            var date = DateTime.Parse(fecha + " " + hora);

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
            client.InsertEventos(nombre, date, ubicacion, guia, 1);
            
            var consulta = client.GetEventos(4).ToArray<EventosModel>();    //Esto generara el qr para el campo con la primary key 4
            GenerarQR(consulta);
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public void GenerarQR(EventosModel[] model)
        {   
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(model.First().m_Nombre, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            ImageSource img = BitmapToImageSource(code.GetGraphic(5));
            QR.Source = img;
        }
    }
}
