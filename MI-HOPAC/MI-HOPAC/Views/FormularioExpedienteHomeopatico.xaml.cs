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
    /// Lógica de interacción para FormularioExpedienteHomeopatico.xaml
    /// </summary>
    public partial class FormularioExpedienteHomeopatico : Page
    {
        public FormularioExpedienteHomeopatico()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertarFormulario();
                MessageBox.Show("Datos insertados correctamente");
                MainExpedientes obj = new MainExpedientes();
                obj.expedientes_Frame.Content = new ExpedientesHomeopaticos();
                this.NavigationService.Navigate(obj);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void InsertarFormulario()
        {
            var client = new MainWebServiceSoapClient();
            client.InsertExpedientesHom(GetAllData());
        }

        public ExpedienteHomeopatiaModel GetAllData()
        {
            ExpedienteHomeopatiaModel model = new ExpedienteHomeopatiaModel();

            model.m_Nombre = txtNombre.Text;
            model.m_Edad = (DateTime)txtEdad.SelectedDate;
            model.m_Sexo = getSexo();
            model.m_EstadoCivil = getEstadoCivil();
            model.m_Ocupacion = txtOcupacion.Text;
            model.m_Domicilio = txtDomicilio.Text;
            model.m_Correo = txtCorreo.Text;
            model.m_Telefono = txtFijo.Text;
            model.m_Movil = txtFijo.Text;
            model.m_CiudadOrigen = txtCiudadDeOrigen.Text;
            model.m_CiudadReside = txtCiudadReside.Text;
            model.m_Religion = txtReligion.Text;
            model.m_Escolaridad = txtEscolaridad.Text;
            model.m_AntHeredo = new TextRange(AntecedentesFamiliares.Document.ContentStart, AntecedentesFamiliares.Document.ContentEnd).Text;
            model.m_AntPersonales = new TextRange(AntecedentesPersonales.Document.ContentStart, AntecedentesPersonales.Document.ContentEnd).Text;
            model.m_TA = txtTA.Text;
            model.m_FC = txtFC.Text;
            model.m_FR = txtFR.Text;
            model.m_Temp = txtTemperatura.Text;
            model.m_Peso = txtPeso.Text;
            model.m_Talla = txtTalla.Text;
            model.m_Menarca = txtMenarca.Text;
            model.m_Dismenorrea = getDisminorre();
            model.m_Ritmo = txtRitmo.Text;
            model.m_F = txtRitmoF.Text;
            model.m_D = txtRitmoD.Text;
            model.m_C = txtRitmoC.Text;
            model.m_FUM = txtFUM.Text;
            model.m_IVSA = txtIVSA.Text;
            model.m_G = txtG.Text;
            model.m_A = txtA.Text;
            model.m_P = txtP.Text;
            model.m_C2 = txtC.Text;
            model.m_FPP = txtFPP.Text;
            model.m_FUP = txtFUP.Text;
            model.m_Menopausia = txtMenopausia.Text;
            model.m_Metodo = txtPlanificacion.Text;
            model.m_Estudios = txtEstudiosLab.Text;
            model.m_Motivo = new TextRange(MotivoConsulta.Document.ContentStart, MotivoConsulta.Document.ContentEnd).Text;
            model.m_fkDoctor = UserControl.Pk.ToString();

            return model;
        }

        public int getDisminorre() { if ((bool)chkDisminorrea.IsChecked) return 1; else return 0; }

        public int getSexo()
        {
            if ((bool)rdHombre.IsChecked)
                return 0;
            else if ((bool)rdMujer.IsChecked)
                return 1;
            else
                return 0;
        }

        public int getEstadoCivil()
        {
            if ((bool)chkCasado.IsChecked)
                return 1;
            if ((bool)chkSoltero.IsChecked)
                return 2;
            if ((bool)chkViudo.IsChecked)
                return 3;
            if ((bool)chkDivorciado.IsChecked)
                return 4;
            else
                return 0;
        }
    }
}
