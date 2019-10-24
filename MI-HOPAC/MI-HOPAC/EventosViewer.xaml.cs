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

namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para EventosViewer.xaml
    /// </summary>
    public partial class EventosViewer : Page
    {
        public EventosViewer()
        {
            InitializeComponent();
            FillSection();
        }

        void FillSection()
        {
            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
            //Consultamos todos los eventos
            var result = client.GetEventos(UserControl.Pk).ToArray<EventosModel>();
            List<Foundation.EventosSection> eventos = new List<Foundation.EventosSection>();

            //Para cada evento de la base de datos, crearemos una instacioa de un EventosSection.
            foreach (EventosModel i in result)
            {
                var section = new Foundation.EventosSection(i.m_Nombre, i.m_Fecha.ToString("hh:mm tt"),
                              i.m_Fecha.ToString("MM/dd/yyyy"), i.m_Guia, i.m_Ubicacion, EventosSection.GenerarQR(i));
                //Lo aniadimos a la lista
                eventos.Add(section);
            }
            //Le aniadimos su ItemSource para podelo mostrar
            sectionEventos.ItemsSource = eventos;
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Obtenemos el data context (todas las propiedades de cada evento)
            var src = (MaterialDesignThemes.Wpf.PackIcon)e.Source;
            var datactx = src.DataContext;
            var data = (EventosSection)datactx;

            //Guardamos el qr
            var qr = data.qrSource;

            PrintDialog pDialog = new PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            // Mostramos el dialogo de imprimir
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                var dv = new DrawingVisual();
                using (var dc = dv.RenderOpen())
                {
                    //Generamos un visual del Qr
                    dc.DrawImage(qr, new Rect(200, 200, (qr.Width) * 3, (qr.Height) * 3));
                }
                //Lo imprimimos
                pDialog.PrintVisual(dv, "QR de Evento.");
            }
        }
    }
}
