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
            var selected = (InventarioHomeopatiaSection)GridInventario.SelectedItem;
            var inputDialog = new InventarioHomeopatiaDialog("Actualice los datos del inventario.");
            var client = new MainWebServiceSoapClient();

            if (selected is null)
            {
                MessageBox.Show("Debes seleccionar un campo para modificar!");
            }
            else
            {
                inputDialog.Nombre = selected.Nombre;
                inputDialog.Potencia = selected.Potencia;
                inputDialog.Cantidad = selected.Cantidad.ToString();

                if (inputDialog.ShowDialog() == true)
                {
                    client.UpdateInventarioHomeopatia(inputDialog.Nombre, Int32.Parse(inputDialog.Potencia), Int32.Parse(inputDialog.Cantidad), selected.id);
                }
            }

            GridInventario.ItemsSource = null;
            Consolidate();
        }

        private void Agr_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new InventarioHomeopatiaDialog("Ingrese los datos del inventario.");
            var client = new MainWebServiceSoapClient();

            if (inputDialog.ShowDialog() == true)
            {    
                client.InsertInventarioHomeopatia(inputDialog.Nombre, Int32.Parse(inputDialog.Potencia), Int32.Parse(inputDialog.Cantidad), UserControl.Pk);
            }
            GridInventario.ItemsSource = null;
            Consolidate();
        }

        private void Eli_Click(object sender, RoutedEventArgs e)
        {
            var selected = (InventarioHomeopatiaSection)GridInventario.SelectedItem;
            var client = new MainWebServiceSoapClient();
            
            if(selected is null)
            {
                MessageBox.Show("Debes seleccionar un campo a eliminar!");
            }
            else
            {
                client.DeleteInventarioHomeopatia(selected.id);
                GridInventario.ItemsSource = null;
                Consolidate();
            }
        }

        private void Consolidate()
        {
            DataInventarioHomeopatia = new List<InventarioHomeopatiaSection>();

            var client = new MainWebServiceSoapClient();
            var result = client.GetInventarioHomeopatia(UserControl.Pk).ToList<InventarioHomeopatiaModel>();

            foreach(var item in result)
            {
                var inventarioRow = new InventarioHomeopatiaSection();
                inventarioRow.Nombre   = item.m_Nombre;
                inventarioRow.Potencia = item.m_Potencia.ToString();
                inventarioRow.Cantidad = item.m_Cantidad;
                inventarioRow.id       = item.m_IdInventarioHomeopatia;
                DataInventarioHomeopatia.Add(inventarioRow);
            }
            DataContext = this;
            GridInventario.ItemsSource = DataInventarioHomeopatia;
        }
    }
}
