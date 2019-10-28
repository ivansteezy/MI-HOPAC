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

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para VerificacionDialog.xaml
    /// </summary>
    public partial class VerificacionDialog : Window
    {
        int code;
        public VerificacionDialog(int code)
        {
            InitializeComponent();
            this.code = code;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
                return false;
            else
                return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos())
                if(code == Int32.Parse(txtCode.Text))
                    this.DialogResult = true;
                else
                    MessageBox.Show("Codigo incorrecto!");
            else
                MessageBox.Show("Ingresa tu codigo de verificacion!");
        }

        public string Nombre { get { return txtCode.Text; } }
    }
}
