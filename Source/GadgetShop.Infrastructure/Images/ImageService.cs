using System;
using GadgetShop.Infrastructure.Content;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace GadgetShop.Infrastructure.Images
{
    public class ImageService : IImageService
    {
        const int ThumbWidth = 64;
        const int ThumbHeight = 64;
        const string ThumbPostfix = "thumb";

        IContentManager _contentManager;
        IImageProcessor _imageProcessor;

        public ImageService(IImageProcessor imageProcessor, IContentManager contentManager)
        {
            _contentManager = contentManager;
            _imageProcessor = imageProcessor;
        }

        public void CreateThumb(string partition, string imageName)
        {
            var imageData = _contentManager.Get(partition, imageName);
            var scaledImageData = _imageProcessor.Scale(imageData, ThumbWidth, ThumbHeight);
            var thumbImageName = GetThumbImageName(imageName);
            _contentManager.Put(partition, thumbImageName, scaledImageData, "image/png");
        }

        public string GetImageUrl(string partition, string imageName)
        {
            var imageUrl = _contentManager.GetUrl(partition, imageName);
            return imageUrl;
        }

        public string GetThumbImageUrl(string partition, string imageName)
        {
            var thumbImageName = GetThumbImageName(imageName);
            var imageUrl = _contentManager.GetUrl(partition, thumbImageName);
            return imageUrl;

        }

        string GetThumbImageName(string imageName)
        {
            var fileName = Path.GetFileNameWithoutExtension(imageName);
            var extension = Path.GetExtension(imageName);
            var thumbImageName = string.Format("{0}_thumb{1}", fileName, extension);
            return thumbImageName;
        }
    }
}
