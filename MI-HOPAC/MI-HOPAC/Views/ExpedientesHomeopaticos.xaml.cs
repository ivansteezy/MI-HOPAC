using MI_HOPAC.Foundation;
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
    /// Interaction logic for ExpedientesHomeopaticos.xaml
    /// </summary>
    public partial class ExpedientesHomeopaticos : Page
    {
        public ExpedientesHomeopaticos()
        {
            InitializeComponent();
            Imprimir();
        }


        private void Imprimir()
        {
            List<ExpedienteHom> Expediente = GetExpedientes();

            if (Expediente.Count > 0)
            {
                ListViewNotas.ItemsSource = Expediente;
            }
        }

        private List<ExpedienteHom> GetExpedientes()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos los expedientes
            var result = client.GetExpedientesHom(UserControl.Pk);

            List<ExpedienteHom> expedientes = new List<ExpedienteHom>();

            //Para cada expedientes de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (MiHomeacupService.ExpedienteHomeopatiaModel i in result)
            {

                var nombre = new ExpedienteHom(i.m_IdExpHom, i.m_Nombre);
                //Lo aniadimos a la lista
                expedientes.Add(nombre);
            }

            //Retornamos la lista con las notas para imprimir
            return expedientes;

        }

    
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Ir a pagina donde se presenta la opcion de crear nuevo expediente


        }

    }
}
