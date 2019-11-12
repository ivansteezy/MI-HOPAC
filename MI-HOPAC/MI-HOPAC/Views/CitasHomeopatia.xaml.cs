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
    /// Interaction logic for CitasHomeopatia.xaml
    /// </summary>
    public partial class CitasHomeopatia : Page
    {
        int pkPaciente = 0;

        public CitasHomeopatia(int PkPaciente)
        {
            InitializeComponent();
            pkPaciente = PkPaciente;
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
            var result = client.GetCitasHomeipatica(pkPaciente);

            List<ExpedienteHom> expedientes = new List<ExpedienteHom>();

            //Para cada expedientes de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (MiHomeacupService.CitasHomeopaticoModel i in result)
            {

                var nombre = new ExpedienteHom(i.m_idcitasaHomeopatia, i.m_Fecha);
                //Lo aniadimos a la lista
                expedientes.Add(nombre);
            }

            //Retornamos la lista con las notas para imprimir
            return expedientes;

        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var exp = ((ExpedienteHom)((System.Windows.FrameworkElement)sender).DataContext);

            //LA PESTAÑA CON SOLO LOS SINTOMAS Y DONDE SE SUBE LA IMAGEN CON INFORAMCION YA LLENA

            var vista = new Repertorizacion(exp);

            MainMenu main = (MainMenu)Window.GetWindow(this);

            main.main_Frame.Navigate(vista);
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LA PESTAÑA CON SOLO LOS SINTOMAS Y DONDE SE SUBE LA IMAGEN

            var vista = new Repertorizacion(pkPaciente);

            MainMenu main = (MainMenu)Window.GetWindow(this);

            main.main_Frame.Navigate(vista);
        }
    }
}
