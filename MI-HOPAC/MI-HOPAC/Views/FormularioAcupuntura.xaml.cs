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
using MI_HOPAC.Foundation;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para FormularioAcupuntura.xaml
    /// </summary>
    public partial class FormularioAcupuntura : Page
    {
        int fkPaciente = 0;
        public FormularioAcupuntura()
        {
            InitializeComponent();
        }

        public FormularioAcupuntura(int Paciente)
        {
            InitializeComponent();
            fkPaciente = Paciente;

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            var res = client.GetCitasAcupunturabyPaciente(Paciente);
            var exp = res[0];
            txtNombre.Text = exp.m_Nombre;
        }

        public FormularioAcupuntura(ExpedienteHom cita)
        {
            InitializeComponent();

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            var res = client.GetCitasAcupunturabyID(cita.Id);
            var expediente = res[0];

            txtNombre.Text = expediente.m_Nombre;
            txtFecha.SelectedDate = (DateTime)expediente.m_Fecha;
            txtShen.Text = expediente.m_Shen;
            txtColor.Text = expediente.m_Color ;
            txtTonicidad.Text = expediente.m_Tonicidad;
            txtLongitud.Text = expediente.m_Longitud;
            txtGrietas.Text = expediente.m_Grietas;
            txtSaburra.Text = expediente.m_Saburra;
            txtHumectacion.Text = expediente.m_Humectacion;
            txtManoDerecha.Text = expediente.m_PulsoD;
            txtManoIzquierda.Text= expediente.m_PulsoI;
            Sintomas.Document.Blocks.Clear();
            Sintomas.Document.Blocks.Add(new Paragraph(new Run(expediente.m_Sintomas)));

            Boton.Visibility = Visibility.Collapsed;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            if(!(string.IsNullOrEmpty(txtNombre.Text)))
            {
                if(fkPaciente == 0)
                {
                    fkPaciente = client.CrearExpedientesAcu(txtNombre.Text, UserControl.Pk);
                }


                var expediente = new CitasAcupunturaModel();

                expediente.m_Nombre = txtNombre.Text;
                expediente.m_Fecha = txtFecha.SelectedDate.Value.Date;
                expediente.m_Shen = txtShen.Text;
                expediente.m_Color = txtColor.Text;
                expediente.m_Tonicidad = txtTonicidad.Text;
                expediente.m_Longitud = txtLongitud.Text;
                expediente.m_Grietas = txtGrietas.Text;
                expediente.m_Saburra = txtSaburra.Text;
                expediente.m_Humectacion = txtHumectacion.Text;
                expediente.m_PulsoD = txtManoDerecha.Text;
                expediente.m_PulsoI = txtManoIzquierda.Text;
                expediente.m_Sintomas = new TextRange(Sintomas.Document.ContentStart, Sintomas.Document.ContentEnd).Text;
                expediente.m_fkPaciente = fkPaciente;

                client.InsertarCitaAcupuntura(expediente);

                MessageBox.Show("Informacion Guardada Exitosamente");

                var vista = new ExpedienteAcupunturas();

                MainMenu main = (MainMenu)Window.GetWindow(this);

                main.main_Frame.Navigate(vista);

            }
            else
            {
                MessageBox.Show("Llene todos los datos");
            }
            
        }
    }
}
