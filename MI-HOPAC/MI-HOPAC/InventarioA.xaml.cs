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
    /// Interaction logic for InventarioA.xaml
    /// </summary>
    public partial class InventarioA : Page
    {

        public List<InvA> elInvent { get; set; }
        public InventarioA()
        {
            InitializeComponent();

            elInvent = new List<InvA>();

            InvA Ejem = new InvA();
            Ejem.Nombre = "Navajas";
            Ejem.Cantidad = 7;



            elInvent.Add(Ejem);

            DataContext = this;



        }


        private void Mod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Agr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Eli_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
