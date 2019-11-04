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
using System.Windows.Shapes;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Interaction logic for NotasInfoDialog.xaml
    /// </summary>
    public partial class NotasInfoDialog : Window
    {
        public NotasInfoDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos())
            {
                string texto = new TextRange(Texto.Document.ContentStart, Texto.Document.ContentEnd).Text;
                string titulo = new TextRange(Titulo.Document.ContentStart, Titulo.Document.ContentEnd).Text;
                string link = new TextRange(Link.Document.ContentStart, Link.Document.ContentEnd).Text;

                MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
                client.InsertNotaInfo(titulo, texto, link, UserControl.Pk);

                this.DialogResult = true;
            }
            else
                MessageBox.Show("Completa todos los campos!");
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(new TextRange(Texto.Document.ContentStart, Texto.Document.ContentEnd).Text) || string.IsNullOrEmpty(new TextRange(Titulo.Document.ContentStart, Titulo.Document.ContentEnd).Text) || string.IsNullOrEmpty(new TextRange(Link.Document.ContentStart, Link.Document.ContentEnd).Text))
                return false;
            else
                return true;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
