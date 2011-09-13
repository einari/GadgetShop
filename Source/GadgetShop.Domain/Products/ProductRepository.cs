using System.Linq;
using System.Collections.Generic;
using GadgetShop.Infrastructure.Entities;
using System;
using GadgetShop.Infrastructure.Content;
using GadgetShop.Infrastructure.Images;

namespace GadgetShop.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        public const string ProductImagePartition = "Products";

        IEntityContext<Product> _productEntityContext;
        IContentManager _contentManager;
        IImageService _imageService;
        IImageProcessor _imageProcessor;

        public ProductRepository(
            IEntityContext<Product> productEntityContext, 
            IContentManager contentManager, 
            IImageProcessor imageProcessor, 
            IImageService imageService)
        {
            _productEntityContext = productEntityContext;
            _contentManager = contentManager;
            _imageService = imageService;
            _imageProcessor = imageProcessor;
        }

        public IEnumerable<Product> GetTopProducts(int count)
        {
            return _productEntityContext.Entities.Take(count);
        }

        public Product GetById(Guid id)
        {
            return _productEntityContext.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productEntityContext.Entities;
        }

        public void New(string name, string shortDescription, string description, double price)
        {
            var product = new Product
            {
                Name = name,
                ShortDescription = shortDescription,
                Description = description,
                Price = price
            };
            _productEntityContext.Insert(product);
        }

        public void SetImage(Guid productId, byte[] imageData)
        {
            var imageName = GetImageName(productId);
            var pngImage = _imageProcessor.ConvertToPng(imageData);
            _contentManager.Put(ProductImagePartition, imageName, pngImage, "image/png");
            _imageService.CreateThumb(ProductImagePartition, imageName);
        }

        public string GetImageUrl(Product product)
        {
            var imageName = GetImageName(product.Id);
            return _imageService.GetImageUrl(ProductImagePartition, imageName);
        }

        public string GetThumbImageUrl(Product product)
        {
            var imageName = GetImageName(product.Id);
            return _imageService.GetThumbImageUrl(ProductImagePartition, imageName);
        }

        string GetImageName(Guid productId)
        {
            return string.Format("{0}.png", productId);
        }
    }
}
