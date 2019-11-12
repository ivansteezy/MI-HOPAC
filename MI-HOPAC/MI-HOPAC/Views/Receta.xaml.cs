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
using MI_HOPAC.Foundation;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Interaction logic for Receta.xaml
    /// </summary>
    public partial class Receta : Page
    {
        public List<Foundation.RecetaInfoSection> DataRecetaInfo { get; set; }
        public List<int> Ids;
        public Receta()
        {
            InitializeComponent();
            LlenarCaja();
            Consolidate();
        }

        public void LlenarCaja()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos los articulos del inventario
            var result = client.GetInventarioHomeopatia(UserControl.Pk);
            List<Foundation.InventarioHomeopatica> medicinas = new List<Foundation.InventarioHomeopatica>();

            //Para cada publicacione de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (MiHomeacupService.InventarioHomeopatiaModel i in result)
            {
                var medicina = new Foundation.InventarioHomeopatica(i.m_IdInventarioHomeopatia, i.m_Nombre, i.m_Potencia, i.m_Cantidad, i.m_FkDoctor);
                //Lo aniadimos a la lista
                medicinas.Add(medicina);
            }

            //Retornamos la lista con las publicaciones para imprimir
            Medicina.ItemsSource = medicinas;
            Medicina.DisplayMemberPath = "Nombre";
            Medicina.SelectedValuePath = "IdInventarioHomeopatia";
        }

        //Agregar
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarDatos())
            {
                var client = new MiHomeacupService.MainWebServiceSoapClient();
                UserControl.fkReceta = client.InsertRecetas(Nombre.Text, DateTime.Now, UserControl.Pk);//en el bton de los cuadros blancos
                client.InsertRecetasInfo(ConstruirReceta());
            
                GridReceta.ItemsSource = null;
                AccumulateItems();
                Consolidate();
            }
        }

        private void AccumulateItems()
        {
            var obj = Medicina.Items[Medicina.SelectedIndex];
            var casting = (InventarioHomeopatica)obj;
            Ids.Add(casting.Id);
        }

        private RecetaInfoModel ConstruirReceta()
        {
            var receta = new RecetaInfoModel();

            receta.m_IdRecetaInfo = 0;
            receta.m_FkReceta = UserControl.fkReceta;
            receta.m_Frencuencia = txtMinuto.Text;
            receta.m_Gotas = Int32.Parse(txtGotas.Text);
            receta.m_FechaI = (DateTime)FechaInicio.SelectedDate;
            receta.m_FechaF = (DateTime)FechaFinal.SelectedDate;
            receta.m_Medicamento = Medicina.Text;

            return receta;
        }

        //Finalizar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int rng = getRNG();
            var client = new MiHomeacupService.MainWebServiceSoapClient();
            client.InsertCodigos(rng, UserControl.Fk, UserControl.fkReceta);
            //client.SubstractItemsHomeopatia(Ids);

            MessageBox.Show("Su codigo de receta es: " + rng);
        }

        int getRNG()
        {
            Random rng = new Random();
            return rng.Next(1000, 9999);
        }

        bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(FechaFinal.SelectedDate.ToString()) || string.IsNullOrEmpty(FechaInicio.SelectedDate.ToString()) ||
               string.IsNullOrEmpty(txtMinuto.Text) || string.IsNullOrEmpty(txtGotas.Text) ||
               string.IsNullOrEmpty(Medicina.SelectedItem.ToString()))
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
            DataRecetaInfo = new List<RecetaInfoSection>();

            var client = new MainWebServiceSoapClient();
            var result = client.GetRecetasInfo(3).ToList<RecetaInfoModel>();//Ojo con el parametro

            foreach (var item in result)
            {
                var recetaRow = new RecetaInfoSection();
                recetaRow.FechaFinal = item.m_FechaF.Date;
                recetaRow.FechaInicio = item.m_FechaI.Date;
                recetaRow.FkReceta = item.m_FkReceta;
                recetaRow.Frecuencia = Int32.Parse(item.m_Frencuencia);
                recetaRow.Id = item.m_IdRecetaInfo;
                recetaRow.Medicamento = item.m_Medicamento;
                recetaRow.Gotas = item.m_Gotas;
                DataRecetaInfo.Add(recetaRow);
            }
            DataContext = this;
            GridReceta.ItemsSource = DataRecetaInfo;
        }
    }
}
