using MI_HOPAC.MiHomeacupService;
using MI_HOPAC.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MI_HOPAC
{
    class UserControl : Window
    {
        public static int Pk       = 0;
        public static int Fk       = 0;
        public static int Medicina = 0;
        public static int fkReceta = 0;
        public static int Citas = 0;

        /*public static void ChecarNotificacion(MainMenu main)
        {
            var client = new MainWebServiceSoapClient();
            var Res = client.CheckInventarioAcupuntura(UserControl.Pk);
            var Lista = new List<Foundation.InventarioAcupuntura>();

            var converter = new System.Windows.Media.BrushConverter();

            var SpeedColor = new System.Windows.Media.SolidColorBrush(Colors.OrangeRed);

            main.Notificaciones.Background = SpeedColor;



            if (Res.Count() > 0)
            {
                foreach (var i in Res)
                {
                    var nuevo = new Foundation.InventarioAcupuntura();
                    nuevo.Nombre = i.m_Nombre + " está terminandose";
                    Lista.Add(nuevo);
                }
            }

            var resp = client.CheckInventarioHomeopatico(UserControl.Pk);

            if (resp.Count() > 0)
            {
                foreach (var i in resp)
                {
                    var nuevo = new Foundation.InventarioAcupuntura();
                    nuevo.Nombre = i.m_Nombre + " está terminandose";
                    Lista.Add(nuevo);
                }
            }

            var citas = client.GetCitas(UserControl.Pk);

            if (citas.Count() > UserControl.Citas)
            {
                for (int i = citas.Count(); i > UserControl.Citas; i--)
                {
                    var nuevo = new Foundation.InventarioAcupuntura();
                    nuevo.Nombre = "Usted tiene una nueva cita!";
                    Lista.Add(nuevo);
                }
                UserControl.Citas = citas.Count();
            }
            ListaNotifiaciones.ItemsSource = Lista;



        }*/

    }
}
