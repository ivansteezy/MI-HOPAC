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
using System.Text.RegularExpressions;
using MI_HOPAC.MiHomeacupService;
using System.Net.Mail;
using System.Net;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        static Random ran = new Random();
        int randomNumber = ran.Next(1000, 9999);

        public Registro()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(ValidarInformacion())
            {
                int med = 0;

                if (radHomeopatia.IsChecked == true)
                    med = 0;
                else if (radAcupuntura.IsChecked == true)
                    med = 1;
                else if (radAmbos.IsChecked == true)
                    med = 2;

                MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();
                var Res = client.InsertCuentaDoctores(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtContrasena.Password,med);

                UserControl.Pk = Res;
                UserControl.Medicina = med;
                UserControl.Fk = client.GetCuentaDoctoresById(UserControl.Pk).ElementAt(0).m_FkDoctor;

                EnviarCorreo(txtCorreo.Text);
            }
        }

        private bool ValidarInformacion()
        {
            //Que se llenen todos los campos
            if (   string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text)
                || string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtContrasena.Password) 
                || string.IsNullOrEmpty(txtConfirmarContrasena.Password ))
            {
                MessageBox.Show("Debe completar la información.");
                return false;
            }
            //Que el correo sea el correcto
            else if (!Regex.IsMatch(txtCorreo.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("El correo es incorrecto.");
                return false;
            }
            //Que la contraseña sea valida
            else if (!Regex.IsMatch(txtContrasena.Password, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?!.*?[¿+_;,.~:´)(}{[|°¬/'#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("La contraseña deberá contener al menos una mayúscula, una minúscula y un número, deberá contar con al menos 8 caracteres sin hacer uso de caracteres especiales.");
                return false;
            }
            //Que las contrsaeñas coincidan
            else if (txtContrasena.Password != txtConfirmarContrasena.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false;
            }
            else return true;
        }

        public void EnviarCorreo(string destinatario)
        {
            try
            {
                var fromAddress = new MailAddress("homeacup@gmail.com", "Servicio Homeacup");
                var toAddress = new MailAddress(destinatario, txtNombre.Text);
                const string fromPassword = "Proyecto1";
                const string subject = "Verificacion de cuenta.";
                string body =
                @"¡Hola! para continuar con el proceso de registro de tu cuenta, ingresa el siguiente codigo en tu aplicación." + 
                "\nCódigo: " + randomNumber + "\nSi usted no solicito el registro a esta cuneta, haga caso omiso.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            AbrirDialogo();
        }

        public void AbrirDialogo()
        {
            var inputDialog = new VerificacionDialog(randomNumber);

            if(inputDialog.ShowDialog() == true)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
        }
    }
}
