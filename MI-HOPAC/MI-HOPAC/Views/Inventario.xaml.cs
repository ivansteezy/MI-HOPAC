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
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Page
    {

        public List<InventarioHomeopatiaSection> ElInventarioH { get; set; }

        public Inventario()
        {
            InitializeComponent();

          

            ElInventarioH = new List<InventarioHomeopatiaSection>();

            InventarioHomeopatiaSection Cosa  = new InventarioHomeopatiaSection();
            InventarioHomeopatiaSection Cosa2 = new InventarioHomeopatiaSection();
            InventarioHomeopatiaSection Cosa3 = new InventarioHomeopatiaSection();

            Cosa.Nombre = "Hola";
            Cosa.Potencia = "20";
            Cosa.Cantidad = 23;

            ElInventarioH.Add(Cosa);

            Cosa2.Nombre = "asda";
            Cosa2.Potencia = "87";
            Cosa2.Cantidad = 15;

            ElInventarioH.Add(Cosa2);

            Cosa3.Nombre = "hjyj";
            Cosa3.Potencia = "74";
            Cosa3.Cantidad = 35;

            ElInventarioH.Add(Cosa3);

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
