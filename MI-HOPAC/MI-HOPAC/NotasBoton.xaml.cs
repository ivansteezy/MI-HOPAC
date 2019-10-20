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

namespace MI_HOPAC
{
    /// <summary>
    /// Interaction logic for NotasBoton.xaml
    /// </summary>
    public partial class NotasBoton : Page
    {
        public NotasBoton()
        {
            InitializeComponent();

            Frame.Content = new Dashboard();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new NotasDigNueva();
        }


    }
}
