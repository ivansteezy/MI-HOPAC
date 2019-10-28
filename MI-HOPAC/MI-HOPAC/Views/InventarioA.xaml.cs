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
    /// Interaction logic for InventarioA.xaml
    /// </summary>
    public partial class InventarioA : Page
    {

        public List<InventarioAcupunturaSection> DataInventarioAcupuntura { get; set; }
        public InventarioA()
        {
            InitializeComponent();
            Consolidate();
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            var selected = (InventarioAcupunturaSection)GridInventario.SelectedItem;
            var inputDialog = new InventarioAcupunturaDialog("Actualice los datos del inventario.");
            var client = new MainWebServiceSoapClient();

            if (selected is null)
            {
                MessageBox.Show("Debes seleccionar un campo para modificar!");
            }
            else
            {
                inputDialog.Nombre = selected.Nombre;
                inputDialog.Cantidad = selected.Cantidad.ToString();

                if (inputDialog.ShowDialog() == true)
                {
                    client.UpdateInventarioAcupuntura(inputDialog.Nombre, Int32.Parse(inputDialog.Cantidad), selected.id);
                }
            }

            GridInventario.ItemsSource = null;
            Consolidate();
        }

        private void Agr_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new InventarioAcupunturaDialog("Ingrese los datos del inventario.");
            var client = new MainWebServiceSoapClient();

            if (inputDialog.ShowDialog() == true)
            {
                client.InsertInventarioAcupuntura(inputDialog.Nombre, Int32.Parse(inputDialog.Cantidad), UserControl.Pk);
            }
            GridInventario.ItemsSource = null;
            Consolidate();
        }

        private void Eli_Click(object sender, RoutedEventArgs e)
        {
            var selected = (InventarioAcupunturaSection)GridInventario.SelectedItem;
            var client = new MainWebServiceSoapClient();

            if (selected is null)
            {
                MessageBox.Show("Debes seleccionar un campo a eliminar!");
            }
            else
            {
                client.DeleteInventarioAcupuntura(selected.id);
                GridInventario.ItemsSource = null;
                Consolidate();
            }
        }

        private void Consolidate()
        {
            DataInventarioAcupuntura = new List<InventarioAcupunturaSection>();

            var client = new MainWebServiceSoapClient();
            var result = client.GetInventarioAcupuntura(UserControl.Pk).ToList<InventarioAcupunturaModel>();

            foreach (var item in result)
            {
                var inventarioRow = new InventarioAcupunturaSection();
                inventarioRow.Nombre = item.m_Nombre;
                inventarioRow.Cantidad = item.m_Cantidad;
                inventarioRow.id = item.m_IdInventarioAcupuntura;
                DataInventarioAcupuntura.Add(inventarioRow);
            }
            DataContext = this;
            GridInventario.ItemsSource = DataInventarioAcupuntura;
        }
    }
}
