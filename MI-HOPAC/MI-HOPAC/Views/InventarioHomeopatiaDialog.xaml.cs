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
    /// Lógica de interacción para InventarioHomeopatiaDialog.xaml
    /// </summary>
    public partial class InventarioHomeopatiaDialog : Window
    {
        public InventarioHomeopatiaDialog()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos())
                this.DialogResult = true;
            else
                MessageBox.Show("Completa todos los campos!");
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPotencia.Text))
                return false;
            else
                return true;
        }
        
        public string Nombre   { get { return txtNombre.Text; } }
        public int    Cantidad { get { return Int32.Parse(txtCantidad.Text); } }
        public int    Potencia { get { return Int32.Parse(txtPotencia.Text); } }
    }
}
