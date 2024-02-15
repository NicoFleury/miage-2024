using MiageCorp.AwesomeShop.BackForFront.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MiageCorp.AwesomeShop.BackForFront.Services
{
    public class ProductService : IProductService
    {
        private RestClient client;
        private const string ressourcePath = "api/products";

        public ProductService(IConfiguration configuration)
        {
            client = new RestClient(configuration["Api:Products"]);
        }

        public async Task<Product> AddProduct(Product product)
        {
            RestRequest request = new RestRequest(ressourcePath);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(product);
            var response = await client.PostAsync(request);
            if (!response.IsSuccessful)
            {
                throw new BackForFrontException(response.StatusCode, response.ErrorMessage);
            }
            return JsonConvert.DeserializeObject<Product>(response.Content);
        }

        public async Task DeleteProduct(string id)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{id}");
            var response = await client.DeleteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new BackForFrontException(response.StatusCode, response.ErrorMessage);
            }
        }

        public async Task<Product?> GetProductById(string id)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{id}");
            var result = await client.GetAsync<Product>(request);
            return result?.Id != null ? result : null;
        }

        public async Task<List<Product>> GetProducts()
        {
            RestRequest request = new RestRequest(ressourcePath);
            var results = await client.GetAsync<List<Product>>(request);
            return results != null ? results : new List<Product>();
        }

        public async Task UpdateProduct(string id, Product product)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{id}");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(product);
            var response = await client.PutAsync(request);
            if (!response.IsSuccessful)
            {
                throw new BackForFrontException(response.StatusCode, response.ErrorMessage);
            }
        }
    }
}
