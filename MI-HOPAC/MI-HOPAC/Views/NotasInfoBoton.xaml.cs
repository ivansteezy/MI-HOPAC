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
    /// Interaction logic for NotasInfoBoton.xaml
    /// </summary>
    public partial class NotasInfoBoton : Page
    {
        public NotasInfoBoton()
        {
            InitializeComponent();

            Frame.Content = new NotasInformativas();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NotasInfoDialog();
            dialog.ShowDialog();
            Frame.Content = new NotasInformativas();
        }

    }
}
