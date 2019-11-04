using MI_HOPAC.MiHomeacupService;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Interaction logic for NotasInfoNueva.xaml
    /// </summary>
    public partial class NotasInfoNueva : Page
    {
        int id = 0;

        public NotasInfoNueva()
        {
            InitializeComponent();

            var converter = new System.Windows.Media.BrushConverter();

            var brush1 = (Brush)converter.ConvertFromString("#e2f0cb");

            Nota.Background = brush1;

        }

        public NotasInfoNueva(int pk, string titulo, string texto)
        {
            InitializeComponent();

            Titulo.AppendText(titulo);

            Texto.AppendText(texto);

            id = pk;

        }


        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            string titulonota = new TextRange(Titulo.Document.ContentStart, Titulo.Document.ContentEnd).Text;
            string textonota = new TextRange(Texto.Document.ContentStart, Texto.Document.ContentEnd).Text;

            if (textonota == "" || textonota == " " || titulonota == "" || titulonota == " ")
            {
                MessageBox.Show("Lenne todos los datos");
            }
            else
            {
                MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();


                if (id == 0)
                {
                    //insertar                  
                    //client.InsertNotaInfo(titulonota, textonota, UserControl.Pk);

                }
                else
                {
                    //Actualizar
                    client.UpdateNotaInfo(id, titulonota, textonota);

                }


                //Regresar a la Vista Inicial
                var vista = new NotasInfoBoton();

                MainMenu main = (MainMenu)Window.GetWindow(this);

                main.main_Frame.Navigate(vista);

            }

        }
    }
}
