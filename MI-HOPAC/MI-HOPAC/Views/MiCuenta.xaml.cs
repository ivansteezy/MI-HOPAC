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
    /// Lógica de interacción para MiCuenta.xaml
    /// </summary>
    public partial class MiCuenta : Page
    {
        public MiCuenta()
        {
            InitializeComponent();
            Consolidate();
        }

        private void Consolidate()
        {

            var client = new MainWebServiceSoapClient();
            var res = client.GetDoctores(UserControl.Pk).ToList<DoctoresModel>().FirstOrDefault();

            Cedula.Text = res.m_Cedula.ToString();
            Nombre.Text = res.m_Nombre + " " + res.m_Apellidos;

            try
            {
                mapsBrowser.Source = new Uri(res.m_Ubicacion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
