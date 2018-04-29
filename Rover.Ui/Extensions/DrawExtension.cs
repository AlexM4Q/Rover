using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Rover.Platform.View.Data;

namespace Rover.Ui.Extensions {

    internal static class DrawExtension {

        public static BitmapSource ToBitmapSource(this DrawableBytes drawableBytes) {
            return drawableBytes.Bytes.ToBitmapSource(drawableBytes.Width, drawableBytes.Height, drawableBytes.ColorComponentsCount);
        }

        public static BitmapSource ToBitmapSource(this byte[] data, int width, int height, int colorComponentsCount = 1) {
            var format = colorComponentsCount.ToPixelFormat();

            var wbm = new WriteableBitmap(width, height, 96, 96, format, null);
            wbm.WritePixels(new Int32Rect(0, 0, width, height), data, colorComponentsCount * width, 0);

            return wbm;
        }

        public static PixelFormat ToPixelFormat(this int bbp) {
            switch (bbp) {
                case 1:
                    return PixelFormats.Gray8;
                case 3:
                    return PixelFormats.Bgr24;
                case 4:
                    return PixelFormats.Bgr32;
                default:
                    return PixelFormats.Default;
            }
        }

    }

}