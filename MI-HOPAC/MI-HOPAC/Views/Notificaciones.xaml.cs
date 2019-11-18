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
    /// Lógica de interacción para Notificaciones.xaml
    /// </summary>
    public partial class Notificaciones : Page
    {
        public Notificaciones()
        {
            InitializeComponent();
            Consolidate();
        }

        public void Consolidate()
        {

            var client = new MainWebServiceSoapClient();

            var Res = client.CheckInventarioAcupuntura(UserControl.Pk);

            var Lista = new List<Foundation.InventarioAcupuntura>();

            if(Res.Count() > 0)
            {

                foreach (var i in Res)
                {
                    var nuevo = new Foundation.InventarioAcupuntura();

                    nuevo.Nombre = i.m_Nombre + " Esta terminandose";

                    Lista.Add(nuevo);

                }

            }


            var resp = client.CheckInventarioHomeopatico(UserControl.Pk);

            if (resp.Count() > 0)
            {

                foreach (var i in Res)
                {
                    var nuevo = new Foundation.InventarioAcupuntura();

                    nuevo.Nombre = i.m_Nombre + " Esta terminandose";

                    Lista.Add(nuevo);

                }

            }


            ListaNotifiaciones.ItemsSource = Lista;




        }
    }
}
