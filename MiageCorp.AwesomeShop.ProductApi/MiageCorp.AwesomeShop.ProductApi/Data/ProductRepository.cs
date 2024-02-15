using MiageCorp.AwesomeShop.ProductApi.Models;
using MongoDB.Driver;

namespace MiageCorp.AwesomeShop.ProductApi.Data
{
    public class ProductRepositoryv : IProductRepository
    {
        private IMongoCollection<Product> Ctx { get; set; }

        public ProductRepositoryv(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration["MongoHost"]);
            Ctx = client.GetDatabase("Products").GetCollection<Product>("Products");
        }

        public void SaveProduct(Product product)
        {
            var entity = GetById(product.Id);
            if (entity == null)
            {
                Ctx.InsertOne(product);
                return;
            }
            Ctx.FindOneAndReplace(Builders<Product>.Filter.Eq("Id", product.Id), product);

        }

        public void DeleteProduct(string id)
        {
            Ctx.FindOneAndDelete(Builders<Product>.Filter.Eq("Id", id));
        }

        public List<Product> GetAll()
        {
            return Ctx.Find(Builders<Product>.Filter.Empty).ToList();
        }

        public Product? GetById(string id)
        {
            return Ctx.Find(Builders<Product>.Filter.Eq("Id", id)).ToList().SingleOrDefault();
        }

    }
}
