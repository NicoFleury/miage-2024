using MiageCorp.AwesomeShop.ProductApi.Data;
using MiageCorp.AwesomeShop.ProductApi.Exceptions;
using MiageCorp.AwesomeShop.ProductApi.Models;

namespace MiageCorp.AwesomeShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository ProductRepository { get; set; }

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            ProductRepository.SaveProduct(product);
            return product;
        }

        public void DeleteProduct(string id)
        {
            ProductRepository.DeleteProduct(id);
        }

        public Product? GetProductById(string id)
        {
            return ProductRepository.GetById(id);
        }

        public List<Product> GetProducts()
        {
            return ProductRepository.GetAll();
        }

        public void UpdateProduct(string id, Product product)
        {
            var entity = ProductRepository.GetById(id);
            if(entity == null)
            {
                throw new UnkownProductException();
            }
            product.Id = id;
            ProductRepository.SaveProduct(product);
        }
    }
}
