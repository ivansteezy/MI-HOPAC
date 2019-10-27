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
using MI_HOPAC.MiHomeacupService;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Page
    {

        public List<InventarioHomeopatiaSection> DataInventarioHomeopatia { get; set; }
        public Inventario()
        {
            InitializeComponent();
            Consolidate();
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Agr_Click(object sender, RoutedEventArgs e)
        {
            //Insertar nombre, potencia y cantidad
            var inputDialog = new InventarioHomeopatiaDialog();
            if(inputDialog.ShowDialog() == true)
            {
                var client = new MainWebServiceSoapClient();
                client.InsertInventarioHomeopatia(inputDialog.Nombre, inputDialog.Potencia, inputDialog.Cantidad, UserControl.Fk);
            }
            GridInventario.ItemsSource = null;
            Consolidate();
        }

        private void Eli_Click(object sender, RoutedEventArgs e)
        {
            var selected = (InventarioHomeopatiaSection)GridInventario.SelectedItem;
            var client = new MainWebServiceSoapClient();
            client.DeleteInventarioHomeopatia(selected.Nombre, UserControl.Fk);
            GridInventario.ItemsSource = null;
            Consolidate();
        }

        private void Consolidate()
        {
            DataInventarioHomeopatia = new List<InventarioHomeopatiaSection>();

            var client = new MainWebServiceSoapClient();
            var result = client.GetInventarioHomeopatia(UserControl.Fk).ToList<InventarioHomeopatiaModel>();

            foreach(var item in result)
            {
                var inventarioRow = new InventarioHomeopatiaSection();
                inventarioRow.Nombre   = item.m_Nombre;
                inventarioRow.Potencia = item.m_Potencia.ToString();
                inventarioRow.Cantidad = item.m_Cantidad;
                DataInventarioHomeopatia.Add(inventarioRow);
            }
            DataContext = this;
            GridInventario.ItemsSource = DataInventarioHomeopatia;
        }
    }
}
