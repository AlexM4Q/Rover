using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;

namespace Rover.Platform.View.Data {

    public class DrawableBytes {

        public static readonly IReadOnlyList<int> SupportedBpp = new[] {8, 24, 32};

        public readonly byte[] Bytes;

        public readonly int Width;

        public readonly int Height;

        public readonly int Bpp;

        public readonly int ColorComponentsCount;

        public DrawableBytes(int width, int height, int bpp = 8, byte[] bytes = null) {
            Width = width;
            Height = height;
            Bpp = bpp;

            CheckBpp(Bpp);

            ColorComponentsCount = Bpp / 8;

            var realBytesCount = Width * Height * ColorComponentsCount;

            if (bytes == null) {
                Bytes = new byte[realBytesCount];
            } else {
                if (realBytesCount != bytes.Length) {
                    throw new ArgumentException($"Incorrect data. Bytes count: {bytes.Length}, expected: {realBytesCount}");
                }

                Bytes = bytes;
            }
        }

        public Color GetPixel(int x, int y) {
            var i = GetIndex(x, y);

            switch (Bpp) {
                case 8:
                    return Color.FromArgb(
                        Bytes[i],
                        Bytes[i],
                        Bytes[i]
                    );
                case 16:
                    return Color.FromArgb(
                        0,
                        Bytes[i + 1],
                        Bytes[i]
                    );
                case 24:
                    return Color.FromArgb(
                        Bytes[i + 2],
                        Bytes[i + 1],
                        Bytes[i]
                    );
                case 32:
                    return Color.FromArgb(
                        Bytes[i + 3],
                        Bytes[i + 2],
                        Bytes[i + 1],
                        Bytes[i]
                    );
                default:
                    throw IncorrectBppArgumentException;
            }
        }

        public void SetPixel(int x, int y, Color color) => SetPixel(x, y, color.B, color.G, color.R, color.A);

        public void SetPixel(int x, int y, byte b, byte g = 0, byte r = 0, byte a = 255) => SetPixel(GetIndex(x, y), b, g, r, a);

        public void SetPixel(int i, byte b, byte g = 0, byte r = 0, byte a = 255) {
            switch (Bpp) {
                case 8:
                    Bytes[i] = b;
                    break;
                case 16:
                    Bytes[i] = b;
                    Bytes[i + 1] = g;
                    break;
                case 24:
                    Bytes[i] = b;
                    Bytes[i + 1] = g;
                    Bytes[i + 2] = r;
                    break;
                case 32:
                    Bytes[i] = b;
                    Bytes[i + 1] = g;
                    Bytes[i + 2] = r;
                    Bytes[i + 3] = a;
                    break;
                default:
                    throw IncorrectBppArgumentException;
            }
        }

        public int GetSample(int x, int y, int band) {
            var pixelColor = GetPixel(x, y);
            switch (band) {
                case 0:
                    return pixelColor.R;
                case 1:
                    return pixelColor.G;
                case 2:
                    return pixelColor.B;
                default:
                    throw new ArgumentException(nameof(band));
            }
        }

        public void SetSample(int x, int y, int band, byte value) {
            var oldColor = GetPixel(x, y);
            switch (band) {
                case 0:
                    SetPixel(x, y, value, oldColor.G, oldColor.B);
                    break;
                case 1:
                    SetPixel(x, y, oldColor.R, value, oldColor.B);
                    break;
                case 2:
                    SetPixel(x, y, oldColor.R, oldColor.G, value);
                    break;
                default:
                    throw new ArgumentException(nameof(band));
            }
        }

        private int GetIndex(int x, int y) {
            var index = (y * Width + x) * ColorComponentsCount;
            var maxIndex = Bytes.Length - ColorComponentsCount;

            if (index > maxIndex) {
                throw new IndexOutOfRangeException($"Index: {index}, Max: {maxIndex}");
            }

            return index;
        }

        /// <summary>
        /// Проверяет вхождение значение bpp в список поддерживаемых
        /// </summary>
        /// <param name="bpp">бит на пиксель</param>
        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private static void CheckBpp(int bpp) {
            if (SupportedBpp.Contains(bpp)) return;
            throw IncorrectBppArgumentException;
        }

        /// <summary>
        /// Генерирует исключение не корректного bpp
        /// </summary>
        /// <returns>объект исключения</returns>
        private static ArgumentException IncorrectBppArgumentException => new ArgumentException($"Only {string.Join(",", SupportedBpp)} bpp images are supported");

    }

}