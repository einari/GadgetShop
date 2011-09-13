namespace GadgetShop.Infrastructure.Images
{
    public interface IImageProcessor
    {
        byte[] Scale(byte[] imageData, int width, int height);
        byte[] ConvertToPng(byte[] imageData);
    }
}
