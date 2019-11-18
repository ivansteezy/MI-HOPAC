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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MI_HOPAC.MiHomeacupService;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para RecetaAcupuntura.xaml
    /// </summary>
    public partial class RecetaAcupuntura : Page
    {
        List<AcupunturaPair> Ids = new List<AcupunturaPair>();
        public List<Foundation.InventarioAcupuntura> DataAcupuntura { get; set; }

        List<Foundation.InventarioAcupuntura> inventario = new List<Foundation.InventarioAcupuntura>();
        public RecetaAcupuntura()
        {
            InitializeComponent();
            LlenarCaja();
        }

        public void LlenarCaja()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos los articulos del inventario
            var result = client.GetMayoresInventarioAcupuntura(UserControl.Pk);
            

            //Para cada publicacione de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (var i in result)
            {
                var inv = new Foundation.InventarioAcupuntura();
                inv.Nombre = i.m_Nombre;
                inv.Cantidad = i.m_Cantidad;
                inv.Id = i.m_IdInventarioAcupuntura;
                //Lo aniadimos a la lista
                inventario.Add(inv);
            }

            //Retornamos la lista con las publicaciones para imprimir
            Inventario.ItemsSource = inventario;
            Inventario.DisplayMemberPath = "Nombre";
            Inventario.SelectedValuePath = "IdInventarioAcupuntura";
        }

        //Agregar
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos())
            {
                var client = new MiHomeacupService.MainWebServiceSoapClient();

                GridAcupuntura.ItemsSource = null;
                AccumulateItems();
                Consolidate();
            }
        }

        private void AccumulateItems()
        {
            var obj = Inventario.Items[Inventario.SelectedIndex];
            var casting = (Foundation.InventarioAcupuntura)obj;
            AcupunturaPair pair = new AcupunturaPair();
            pair.Cantidad = int.Parse(txtCantidad.Text);
            pair.Id = casting.Id;
            Ids.Add(pair);
        }

        //Finalizar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int rng = getRNG();
            var client = new MiHomeacupService.MainWebServiceSoapClient();
            client.InsertCodigos(rng, UserControl.Pk, -1);

            client.SubstractItemsAcupuntura(Ids.ToArray());

            MessageBox.Show("Su codigo de paciente es: " + rng);

            var vista = new Dashboard();
            MainMenu main = (MainMenu)Window.GetWindow(this);
            main.main_Frame.Navigate(vista);
        }

        int getRNG()
        {
            Random rng = new Random();
            return rng.Next(1000, 9999);
        }

        bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(Inventario.SelectedItem.ToString()) || string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debes completar todos los campos!");
                return false;
            }
            else
                return true;
        }

        //Show data
        private void Consolidate()
        {
            DataAcupuntura = new List<Foundation.InventarioAcupuntura>();

            var row = new Foundation.InventarioAcupuntura();
            row.Cantidad = Int32.Parse(txtCantidad.Text);
            row.Nombre = Inventario.Text;
            DataAcupuntura.Add(row);

            DataContext = this;
            GridAcupuntura.ItemsSource = DataAcupuntura;

            txtCantidad.Clear();
        }
    }
}
