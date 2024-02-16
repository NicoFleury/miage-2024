using MiageCorp.AwesomeShop.ProductApi.Models;

namespace MiageCorp.AwesomeShop.ProductApi.Data
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product? GetById(string id);
        
        void SaveProduct(Product product);

        void DeleteProduct(string id);
    }
}
