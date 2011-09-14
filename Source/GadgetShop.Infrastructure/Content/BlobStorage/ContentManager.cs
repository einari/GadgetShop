using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Collections.Generic;

namespace GadgetShop.Infrastructure.Content.BlobStorage
{
    public class ContentManager : IContentManager
    {
        Dictionary<string, CloudBlobContainer> _containers = new Dictionary<string, CloudBlobContainer>();

        CloudStorageAccount _account;
        CloudBlobClient _client;

        public ContentManager(CloudStorageAccount account)
        {
            _account = account;
            _client = account.CreateCloudBlobClient();
        }

        CloudBlobContainer GetContainerForPartition(string partition)
        {
            partition = partition.ToLowerInvariant();

            if (_containers.ContainsKey(partition))
                return _containers[partition];


            var container = _client.GetContainerReference(partition);
            container.CreateIfNotExist();

            var permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);

            _containers[partition] = container;
            return container;
        }


        public void Put(string partition, string name, byte[] data, string contentType)
        {
            var container = GetContainerForPartition(partition);
            container.CreateIfNotExist();
            var blob = container.GetBlockBlobReference(name);
            blob.Properties.ContentType = contentType;
            blob.UploadByteArray(data);
        }

        public byte[] Get(string partition, string name)
        {
            var container = GetContainerForPartition(partition);
            var blob = container.GetBlockBlobReference(name);
            var data = blob.DownloadByteArray();
            return data;
        }

        public string GetUrl(string partition, string name)
        {
            var baseUri = _client.BaseUri.ToString();
            return string.Format("{0}{1}{2}/{3}", 
                baseUri , 
                baseUri.EndsWith("/")?string.Empty:"/",
                partition.ToLowerInvariant(), 
                name.ToLowerInvariant());
        }
    }
}
