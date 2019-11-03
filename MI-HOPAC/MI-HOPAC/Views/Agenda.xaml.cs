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
using MI_HOPAC.Foundation;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para Agenda.xaml
    /// </summary>
    public partial class Agenda : Page
    {
        public List<CitaSection> DataCitas { get; set; }
        public Agenda()
        {
            InitializeComponent();
            Consolidate();
        }

        public void Consolidate()
        {
            DataCitas = new List<CitaSection>();

            var client = new MainWebServiceSoapClient();
            var result = client.GetCitas(UserControl.Pk).ToList();
            var pacientes = client.GetPacientes(UserControl.Pk);

            foreach(var item in result)
            {
                var paciente = from c in pacientes
                               where c.m_IdPaciente == item.m_FkPaciente
                               select c.m_Nombre;

                var citasRow = new CitaSection();
                citasRow.Paciente = paciente.First();
                citasRow.Fecha = item.m_Fecha.ToString();
                DataCitas.Add(citasRow);
            }
            DataContext = this;
            ListaCitas.ItemsSource = DataCitas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NuevaCitaDialog dlg = new NuevaCitaDialog();
            var client = new MainWebServiceSoapClient();
            
            if (dlg.ShowDialog() == true)
            {
                client.InsertCita(dlg.Fecha, dlg.idPaciente, UserControl.Pk);
            }

            ListaCitas.ItemsSource = null;
            Consolidate();
        }
    }
}
