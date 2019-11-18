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
            Consolidate();
        }

        public FormularioExpedienteHomeopatico(int Id)
        {
            InitializeComponent();

            //IMPRIMIR TODO
            Rellenar(Id);

        }

        private void Consolidate()
        {
            var listaReligion = new List<string>()
            {
                "Judía", "Católica", "Cristiana", "Ortodoxa",
                "Testigos de Jehová", "Islámica", "Mormona",
                "Budistas", "Krishnas", "Ateísta", "Otra"
            };
            txtReligion.ItemsSource = listaReligion;

            var listaEscolaridad = new List<string>()
            {
                "Preescolar", "Primaria", "Secundaria",
                "Preparatoria o bachillerato", "Licienciatura",
                "Maestría", "Doctorado"
            };
            txtEscolaridad.ItemsSource = listaEscolaridad;

            var listaAntecedentes = new List<string>()
            {
                "Tuberculosis", "DiabetesMellitus", "Hipertensión", "Carcinomas", "Cardiopatías",
                "Hepatopatías", "Nefropatías", "EnfermedadesEndocrinas", "EnfermedadesMentales",
                "Epilepsia", "Asma", "EnfermedadesHematológicas"
            };
            AntecedentesFamiliares.ItemsSource = listaAntecedentes;

            var listaAntecedentesPersonales = new List<string>()
            {
                "Enfermedades Infecciosas de la infancia", "Tuberculosis",
                "Enfermedades Venéreas", "Fiebre Tifoidea", "Salmonelosis",
                "Neumonías", "Paludismo", "Parasitosis", "Alergias", "Padecimientos Articulares",
                "Intervenciones Quirúrgicas", "Hospitalizaciones", "Traumatismos/Accidentes",
                "Perdida del conocimiento", "Intolerancia a medicamentos de cualquier tipo",
                "Transfusiones"
            };
            AntecedentesPersonales.ItemsSource = listaAntecedentesPersonales;
        }

        private string GetAntecedentesFamiliares()
        {
            StringBuilder strbld = new StringBuilder();
            foreach (var item in ListaAntecedentesFamiliares.Items)
            {
                strbld.Append(item.ToString());
                strbld.Append(", ");
            }
            return strbld.ToString().Trim().TrimEnd(',');
        }

        private string GetAntecedentesPersonales()
        {
            StringBuilder strbld = new StringBuilder();
            foreach (var item in ListaAntecedentesPersonales.Items)
            {
                strbld.Append(item.ToString());
                strbld.Append(", ");
            }
            return strbld.ToString().Trim().TrimEnd(',');
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertarFormulario();
                MessageBox.Show("Datos insertados correctamente");

                var vista = new ExpedientesHomeopaticos();

                MainMenu main = (MainMenu)Window.GetWindow(this);

                main.main_Frame.Navigate(vista);
            }
            catch (Exception ex)
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
            model.m_AntHeredo = GetAntecedentesFamiliares();
            model.m_AntPersonales = GetAntecedentesPersonales();
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
                return 1;
            else if ((bool)rdMujer.IsChecked)
                return 0;
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

        private void AgregarAntecedentesFamiliares_Click(object sender, RoutedEventArgs e)
        {
            ListaAntecedentesFamiliares.Items.Add(AntecedentesFamiliares.Text);
        }

        private void AgregarAntecedentesPersonales_Click(object sender, RoutedEventArgs e)
        {
            ListaAntecedentesPersonales.Items.Add(AntecedentesPersonales.Text);
        }


        public void Rellenar(int Pk)
        {

            var client = new MainWebServiceSoapClient();
            var res = client.GetExpedienteHomByID(Pk);
            var i = res[0];

            var listaReligion = new List<string>()
            {
                "Judía", "Católica", "Cristiana", "Ortodoxa",
                "Testigos de Jehová", "Islámica", "Mormona",
                "Budistas", "Krishnas", "Ateísta", "Otra"
            };
            txtReligion.ItemsSource = listaReligion;

            var listaEscolaridad = new List<string>()
            {
                "Preescolar", "Primaria", "Secundaria",
                "Preparatoria o bachillerato", "Licienciatura",
                "Maestría", "Doctorado"
            };
            txtEscolaridad.ItemsSource = listaEscolaridad;

            txtNombre.Text = i.m_Nombre;
            txtEdad.SelectedDate = i.m_Edad;


            if (i.m_Sexo == 0)
                rdMujer.IsChecked = true;
            else
                rdHombre.IsChecked = true;


            if (i.m_EstadoCivil == 1)
                chkCasado.IsChecked = true;
            else if (i.m_EstadoCivil == 2)
                chkSoltero.IsChecked = true;
            else if (i.m_EstadoCivil == 3)
                chkViudo.IsChecked = true;
            else
                chkDivorciado.IsChecked = true;

            txtOcupacion.Text = i.m_Ocupacion;
            txtDomicilio.Text = i.m_Domicilio;
            txtCorreo.Text = i.m_Correo;

            txtFijo.Text = i.m_Telefono;
            txtMovil.Text = i.m_Movil;

            txtCiudadDeOrigen.Text = i.m_CiudadOrigen;
            txtCiudadReside.Text = i.m_CiudadReside;
            txtReligion.Text = i.m_Religion;
            txtEscolaridad.Text = i.m_Escolaridad;

            ListaAntecedentesFamiliares.ItemsSource = i.m_AntHeredo.Split(',').ToList<string>();
            ListaAntecedentesPersonales.ItemsSource = i.m_AntPersonales.Split(',').ToList<string>();

            txtTA.Text = i.m_TA;
            txtFC.Text = i.m_FC;
            txtFR.Text = i.m_FR;
            txtTemperatura.Text = i.m_Temp;
            txtPeso.Text = i.m_Peso;
            txtTalla.Text = i.m_Talla;

            txtMenarca.Text = i.m_Menarca;
            txtRitmo.Text = i.m_Ritmo;

            if (i.m_Dismenorrea == 1)
                chkDisminorrea.IsChecked = true;

            txtRitmoF.Text = i.m_F;
            txtRitmoD.Text = i.m_D;
            txtRitmoC.Text = i.m_C;
            txtFUM.Text = i.m_FUM;
            txtIVSA.Text = i.m_IVSA;
            txtG.Text = i.m_G;
            txtA.Text = i.m_A;
            txtP.Text = i.m_P;
            txtC.Text = i.m_C2;
            txtFPP.Text = i.m_FPP;
            txtFUP.Text = i.m_FUP;
            txtMenopausia.Text = i.m_Menopausia;
            txtPlanificacion.Text = i.m_Metodo;
            txtEstudiosLab.Text = i.m_Estudios;

            MotivoConsulta.Document.Blocks.Clear();
            MotivoConsulta.Document.Blocks.Add(new Paragraph(new Run(i.m_Motivo)));

            BotonGuardar.Visibility = Visibility.Collapsed;
            AgregarAntecedentesFamiliares.Visibility = Visibility.Hidden;
            AgregarAntecedentesPersonales.Visibility = Visibility.Hidden;


        }


    }
}
