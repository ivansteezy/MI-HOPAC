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

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();

            Imprimir();
        }


        private void Imprimir()
        {
            List<NotaSection> notas = GetNotas();

            if (notas.Count > 0)
            {
                ListViewNotas.ItemsSource = notas;
            }
        }

        private List<NotaSection> GetNotas()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos las notas
            var result = client.GetNotasDig(UserControl.Pk);
            List<NotaSection> notes = new List<NotaSection>();

            //Para cada nota de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (MiHomeacupService.NotasDigitalesModel i in result)
             {
                if (i.m_Color == "1")
                    i.m_Color = "#ff9aa2";
                else if(i.m_Color == "2")
                    i.m_Color = "#ffdac1";
                else if (i.m_Color == "3")
                    i.m_Color = "#f7f7b7";
                else if (i.m_Color == "4")
                    i.m_Color = "#e2f0cb";
                else if (i.m_Color == "5")
                    i.m_Color = "#b5ead7";
                else if (i.m_Color == "6")
                    i.m_Color = "#c7ceea";
                    

                var section = new NotaSection(i.m_IdNota, i.m_Text, i.m_Color);
                 //Lo aniadimos a la lista
                 notes.Add(section);
             }

            //Retornamos la lista con las notas para imprimir
            return notes;      

        }

        private void Button_Color(object sender, RoutedEventArgs e)
        {


            var pk = ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Id;

            var color = ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color;

            var texto = ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Texto;

            //MessageBox.Show(((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color);

            if (color == "#FFFF9AA2")  
                ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color = "#FFFFDAC1";        
            else if(color == "#FFFFDAC1")
                ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color = "#FFF7F7B7";
            else if (color == "#FFF7F7B7")
                ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color = "#FFE2F0CB";
            else if (color == "#FFE2F0CB")
                ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color = "#FFB5EAD7";
            else if (color == "#FFB5EAD7")
                ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color = "#FFC7CEEA";
            else if (color == "#FFC7CEEA")
                ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color = "#FFFF9AA2";


            ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Change = 1;


            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            client.UpdateNotaDig(pk, texto, ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color);

            ListViewNotas.Items.Refresh();


        }

        private void Botton_Modificar(object sender, RoutedEventArgs e)
        {
            var pk = ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Id;

            var color = ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Color;

            var texto = ((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Texto;

            var vista = new NotasDigNueva(pk, texto, color);

            MainMenu main = (MainMenu)Window.GetWindow(this);

            main.main_Frame.Navigate(vista);

        }


        private void Botton_Eliminar(object sender, RoutedEventArgs e)
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
            client.DeleteNotaDig(((MI_HOPAC.NotaSection)((System.Windows.FrameworkElement)sender).DataContext).Id);



            Imprimir();

        }

    }


}
