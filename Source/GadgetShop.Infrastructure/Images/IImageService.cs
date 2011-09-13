namespace GadgetShop.Infrastructure.Images
{
    public interface IImageService
    {
        void CreateThumb(string partition, string imageName);
        string GetImageUrl(string partition, string imageName);
        string GetThumbImageUrl(string partition, string imageName);
    }
}
