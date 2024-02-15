using MiageCorp.AwesomeShop.ProductApi.Models;

namespace MiageCorp.AwesomeShop.ProductApi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProductById(string id);

        Product AddProduct(Product product);

        void UpdateProduct(string id, Product product);

        void DeleteProduct(string id);
    }
}
