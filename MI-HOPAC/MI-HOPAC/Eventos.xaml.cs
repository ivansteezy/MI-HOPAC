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

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para Eventos.xaml
    /// </summary>
    public partial class Eventos : Page
    {
        public Eventos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main_Frame.Content = new NuevoEvento();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            main_Frame.Content = new Eventos();
        }
    }
}
