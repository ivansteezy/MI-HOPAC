using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Drawing.Imaging;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para Repertorizacion.xaml
    /// </summary>
    public partial class Repertorizacion : Page
    {
        public string ImagePath { get; set; }
        public Repertorizacion()
        {
            InitializeComponent();
        }

        //Agregar imagen
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var dialog = OpenImage();

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                ImagePath = path;
                RepertorizacionImg.Source = new BitmapImage(new Uri(ImagePath));
            }
        }

        private OpenFileDialog OpenImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selecciona su repertorizacion";

            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";

            return op;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imageSavePath = "../../Resources/Repertorizaciones/" + Guid.NewGuid() + ".jpg";  //A insertar en la base de datos
            var bitmap = new Bitmap(ImagePath);
            System.Drawing.Image img = bitmap; 
            img.Save(imageSavePath, ImageFormat.Jpeg);
        }
    }
}
