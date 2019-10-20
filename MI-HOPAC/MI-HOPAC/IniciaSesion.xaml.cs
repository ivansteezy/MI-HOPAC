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
using System.Text.RegularExpressions;
using MI_HOPAC.MiHomeacupService;


namespace MI_HOPAC
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarInformacion())
            {
                MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

                var Res = client.GetCuentaDoctores(txt_Usuario.Text, txt_Contrasena.Password);

                if(Res.Length > 0)
                {
                    UserControl.Fk = Res.ElementAt(0).m_IdCuentaDoctores;
                    UserControl.Medicina = Res.ElementAt(0).m_Medicina;

                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Correo o Contraseña erronea");
                }
            }
        }

        private bool ValidarInformacion()
        { 
            /*Que la informacion sea completa*/
            if (string.IsNullOrEmpty(txt_Contrasena.Password) || string.IsNullOrEmpty(txt_Usuario.Text))
            {
                MessageBox.Show("Debe completar la información.");
                return false;
            }
            /*Que el correo sea correcto*/
            else if (!Regex.IsMatch(txt_Usuario.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")) //Solo permite el something@something.something
            {
                MessageBox.Show("El correo es incorrecto.");
                return false;
            }
            /*Que la Contraseña sea correcta*/
            else if (!Regex.IsMatch(txt_Contrasena.Password, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?!.*?[¿+_;,.~:´)(}{[|°¬/'#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("La contraseña deberá contener al menos una mayúscula, una minúscula y un número, deberá contar con al menos 8 caracteres sin hacer uso de caracteres especiales.");
                return false;
            }
            else return true;
        }
    }
}
