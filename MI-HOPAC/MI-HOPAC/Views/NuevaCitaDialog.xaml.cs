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
using System.Windows.Shapes;
using MI_HOPAC.MiHomeacupService;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para NuevaCitaDialog.xaml
    /// </summary>
    public partial class NuevaCitaDialog : Window
    {
        static MainWebServiceSoapClient client = new MainWebServiceSoapClient();
        List<PacienteModel> lista = client.GetPacientes(UserControl.Pk).ToList();
        public NuevaCitaDialog()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos())
            {
                this.DialogResult = true;
            }
            else
                MessageBox.Show("Completa todos los campos!");
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txt_Paciente.Text) ||
               string.IsNullOrEmpty(txt_FechaCita.SelectedDate.ToString()) ||
               string.IsNullOrEmpty(txt_HoraCita.SelectedTime.ToString()))
                return false;
            else
                return true;
        }

        private void FillComboBox()
        {
            

            foreach (var item in lista)
            {
                txt_Paciente.Items.Add(item.m_Nombre.ToString());
            }
        }

        public int idPaciente
        {
            get
            {
                var result = from c in lista
                             where c.m_Nombre == txt_Paciente.SelectedItem.ToString()
                             select c.m_IdPaciente;

                return result.First();
            }
        }
        public DateTime Fecha
        {
            get
            {
                return new DateTime(txt_FechaCita.SelectedDate.Value.Year, txt_FechaCita.SelectedDate.Value.Month,
                                    txt_FechaCita.SelectedDate.Value.Day, txt_HoraCita.SelectedTime.Value.Hour,
                                    txt_HoraCita.SelectedTime.Value.Minute, txt_HoraCita.SelectedTime.Value.Second);
            }
        }

    }
}
