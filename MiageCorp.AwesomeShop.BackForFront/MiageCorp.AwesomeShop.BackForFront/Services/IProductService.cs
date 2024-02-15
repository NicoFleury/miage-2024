using MiageCorp.AwesomeShop.BackForFront.Models;

namespace MiageCorp.AwesomeShop.BackForFront.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<Product?> GetProductById(string id);

        Task<Product> AddProduct(Product product);

        Task UpdateProduct(string id, Product product);

        Task DeleteProduct(string id);

    }
}
