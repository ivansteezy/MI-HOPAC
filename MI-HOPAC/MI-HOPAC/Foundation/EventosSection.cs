using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using QRCoder;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using MI_HOPAC.MiHomeacupService;

namespace MI_HOPAC.Foundation
{
    /// <summary>
    /// Clase encargada de almacenar los datos/QR que se mostraran en cada una de las Cards en el EventosViewer
    /// </summary>
    class EventosSection
    {
        #region Propiedades
        public string nombreEvento    { get; set; }
        public string horaEvento      { get; set; }
        public string fechaEvento     { get; set; }
        public string guiaEvento      { get; set; }
        public string ubicacionEvento { get; set; }
        public ImageSource qrSource   { get; set; }
        #endregion

        public EventosSection(string _nombreEvento, string _horaEvento, string _fechaEvento,
                       string _guiaEvento, string _ubicacionEvento, ImageSource _qrSource) => 
                       (nombreEvento, horaEvento, fechaEvento, guiaEvento, ubicacionEvento, qrSource) = 
                       (_nombreEvento, _horaEvento, _fechaEvento, _guiaEvento, _ubicacionEvento, _qrSource);

        //Funcion para convertir un Bitmap a ImageSource para poder mostrarlo
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
               
                return bitmapimage;
            }
        }

        //Funcion para generar un QR
        public static ImageSource GenerarQR(EventosModel model)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(model.m_IdEventos.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            ImageSource img = BitmapToImageSource(code.GetGraphic(5));  //GetGraphic() no da un bitmap, habra que hacerlo ImageSource
            return img;
        }
    }
}
