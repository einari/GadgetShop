using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace GadgetShop.Infrastructure.Images
{
    public class ImageProcessor : IImageProcessor
    {
        public byte[] ConvertToPng(byte[] imageData)
        {
            using( var memoryStream = new MemoryStream(imageData) )
            {
                var outputStream = new MemoryStream();
                var image = Bitmap.FromStream(memoryStream);
                image.Save(outputStream, ImageFormat.Png);
                var convertedImageData = outputStream.ToArray();
                return convertedImageData;
            }
        }

        public byte[] Scale(byte[] imageData, int width, int height)
        {
            using (var memoryStream = new MemoryStream(imageData))
            {
                using (var image = Bitmap.FromStream(memoryStream))
                {
                    using (var scaledImage = new Bitmap(width, height))
                    {
                        using (var scaledGraphics = Graphics.FromImage(scaledImage))
                        {
                            scaledGraphics.DrawImage(image, 0, 0, width, height);
                            using (var scaledMemoryStream = new MemoryStream())
                            {
                                scaledImage.Save(scaledMemoryStream, ImageFormat.Png);
                                var scaledImageData = scaledMemoryStream.ToArray();
                                return scaledImageData;
                                
                            }
                        }
                    }
                }
            }
        }
    }
}
