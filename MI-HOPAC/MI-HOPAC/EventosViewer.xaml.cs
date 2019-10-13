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
            var result = client.GetEventos().ToArray<EventosModel>();
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

    }
}
