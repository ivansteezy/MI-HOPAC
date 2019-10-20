using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MI_HOPAC.Foundation
{
    class OperacionesAsincronas
    {
        public static BitmapImage UpdateProfileImage(string path)
        {
            var bitmap = new Bitmap(path);
            System.Drawing.Image img = bitmap;

            img.Save("../../Resources/ProfilePhoto.png", ImageFormat.Png);

            var bitmapImage = new BitmapImage(new Uri(path));
            return bitmapImage;
        }

        public static BitmapImage UpdateBackgroundImage(string path)
        {
            var bitmap = new Bitmap(path);
            System.Drawing.Image img = bitmap;

            img.Save("../../Resources/back.jpg", ImageFormat.Jpeg);

            var bitmapImage = new BitmapImage(new Uri(path));
            return bitmapImage;
        }
    }
}
