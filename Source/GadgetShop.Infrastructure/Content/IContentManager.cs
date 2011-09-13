namespace GadgetShop.Infrastructure.Content
{
    public interface IContentManager
    {
        void Put(string partition, string name, byte[] data, string contentType);
        byte[] Get(string partition, string name);
        string GetUrl(string partition, string name);
    }
}
