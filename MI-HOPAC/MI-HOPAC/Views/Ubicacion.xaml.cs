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

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para Ubicacion.xaml
    /// </summary>
    public partial class Ubicacion : Page
    {
        public Ubicacion()
        {
            InitializeComponent();
            Consolidate();
        }

        public void Consolidate()
        {
            try
            {
                mapsBrowser.Source = new Uri("https://www.google.com.mx/maps");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Guardamos una url en alguna clase
            Console.WriteLine(mapsBrowser.Source);

            MainMenu main = (MainMenu)Window.GetWindow(this);
            var info = new InformacionPerfil(mapsBrowser.Source.ToString());
            main.main_Frame.Navigate(info);
        }
    }
}
