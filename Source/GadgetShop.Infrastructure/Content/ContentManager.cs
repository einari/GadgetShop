using System;
using System.IO;
using System.Web;

namespace GadgetShop.Infrastructure.Content
{
    public class ContentManager : IContentManager
    {
        const string Root = "Content";

        public void Put(string partition, string name, byte[] data, string contentType)
        {
            var path = GetPath(partition, name);
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllBytes(path, data);
        }

        public byte[] Get(string partition, string name)
        {
            var path = GetPath(partition, name);
            var directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                return new byte[0];

            var bytes = File.ReadAllBytes(path);
            return bytes;
        }

        public string GetUrl(string partition, string name)
        {
            var relativeUrl = GetRelativeUrl(partition, name);
            var absoluteUrl = ConvertRelativeUrlToAbsoluteUrl(relativeUrl);
            return absoluteUrl;
        }

        string GetPath(string partition, string name)
        {
            var relativeUrl = GetRelativeUrl(partition, name);
            var path = HttpContext.Current.Server.MapPath(relativeUrl);
            return path;
        }

        string GetRelativeUrl(string partition, string name)
        {
            return string.Format("~/{0}/{1}/{2}", Root, partition, name);
        }

        public string ConvertRelativeUrlToAbsoluteUrl(string relativeUrl)
        {
            var uri = HttpContext.Current.Request.Url;

            var absoluteUrl = string.Format("{0}://{1}{2}/{3}",
                uri.Scheme,
                uri.Host,
                uri.IsDefaultPort ? string.Empty : ":" + uri.Port,
                relativeUrl.Replace("~/", string.Empty));

            return absoluteUrl;
        }
    }
}
