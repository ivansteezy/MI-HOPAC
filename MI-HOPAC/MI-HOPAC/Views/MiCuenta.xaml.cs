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
            ImpHorario();
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

        private void ImpHorario()
        {

            var client = new MainWebServiceSoapClient();
            var Res = client.GetHorario(UserControl.Pk);
            var Hours = new List<Foundation.Horario>();

            foreach(var i in Res)
            {
                var Hor = new Foundation.Horario();

                if (i.m_FkDia == 1)
                    Hor.Dia = "Lunes";
                else if (i.m_FkDia == 2)
                    Hor.Dia = "Martes";
                else if (i.m_FkDia == 3)
                    Hor.Dia = "Miercoles";
                else if (i.m_FkDia == 4)
                    Hor.Dia = "Jueves";
                else if (i.m_FkDia == 5)
                    Hor.Dia = "Viernes";
                else if (i.m_FkDia == 6)
                    Hor.Dia = "Sabado";
                else if (i.m_FkDia == 7)
                    Hor.Dia = "Domingo";

                Hor.HoraI = i.m_HoraI.TimeOfDay.ToString();
                Hor.HoraF = i.m_HoraF.TimeOfDay.ToString();

                Hours.Add(Hor);
            }
            

            Horario.ItemsSource = Hours;



        }
    }
}
