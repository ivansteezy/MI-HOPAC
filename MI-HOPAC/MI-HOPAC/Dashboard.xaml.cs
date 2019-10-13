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
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();

            List<Nota> notas = GetNotas();

            if (notas.Count > 0)
            {
                ListViewNotas.ItemsSource = notas;              
            }

            var Lista = ListViewNotas;
            
            
        }

        private List<Nota> GetNotas()
        {

            return new List<Nota>()
            {
                new Nota("laskdjalksdjlañskdjlaskd", "Red", 1),
                new Nota("hsdfdsfgsdfg", "Blue", 2),
                new Nota("fshjfgjhdfgn", "Green", 3),
                new Nota("asdfsbrfsdfv", "Purple", 4),
                new Nota("jrtyjfhjfgnwfgwef", "White", 5),
                new Nota("zxczdagadg", "Orange", 6),
                new Nota("adfafoiaeufhyoaduifhoadfuih", "Yellow", 7),              
        };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var y = ((MI_HOPAC.Nota)((System.Windows.FrameworkElement)sender).DataContext).Id;

            MessageBox.Show(y.ToString());

            

        }
    }
}
