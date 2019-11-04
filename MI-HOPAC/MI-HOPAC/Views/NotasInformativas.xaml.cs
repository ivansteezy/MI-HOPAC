using MI_HOPAC.Foundation;
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
using MI_HOPAC.Foundation;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para NotasInformativas.xaml
    /// </summary>
    public partial class NotasInformativas : Page
    {
        public NotasInformativas()
        {
            InitializeComponent();
            Imprimir();
        }


        private void Imprimir()
        {
            List<NotaInfo> notas = GetNotas();

            if (notas.Count > 0)
            {
                ListViewNotas.ItemsSource = notas;
            }
        }

        private List<NotaInfo> GetNotas()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos las notas
            var result = client.GetNotasInfo(UserControl.Pk);
            List<NotaInfo> notes = new List<NotaInfo>();

            //Para cada nota de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (MiHomeacupService.NotasInformativasModel i in result)
            {
                var nota = new NotaInfo(i.m_IdNotas, i.m_Titulo, i.m_Texto, i.m_Link);
                //Lo aniadimos a la lista
                notes.Add(nota);
            }

            //Retornamos la lista con las notas para imprimir
            return notes;

        }

        private void Botton_Modificar(object sender, RoutedEventArgs e)
        {
            var pk = ((MI_HOPAC.Foundation.NotaInfo)((System.Windows.FrameworkElement)sender).DataContext).Id;

            var titulo = ((MI_HOPAC.Foundation.NotaInfo)((System.Windows.FrameworkElement)sender).DataContext).Titulo;

            var texto = ((MI_HOPAC.Foundation.NotaInfo)((System.Windows.FrameworkElement)sender).DataContext).Texto;

            var vista = new NotasInfoNueva(pk, titulo, texto);

            MainMenu main = (MainMenu)Window.GetWindow(this);

            main.main_Frame.Navigate(vista);

        }


        private void Botton_Eliminar(object sender, RoutedEventArgs e)
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
            client.DeleteNotaInfo(((MI_HOPAC.Foundation.NotaInfo)((System.Windows.FrameworkElement)sender).DataContext).Id);

            Imprimir();

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var ellink = ((MI_HOPAC.Foundation.NotaInfo)((System.Windows.FrameworkContentElement)sender).DataContext).Link;
            System.Diagnostics.Process.Start(ellink);
        }
    }

}