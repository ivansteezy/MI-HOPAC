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

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Interaction logic for Receta.xaml
    /// </summary>
    public partial class Receta : Page
    {
        public Receta()
        {
            InitializeComponent();
            LlenarCaja();
        }

        public void LlenarCaja()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos las publicaciones
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
    }
}
