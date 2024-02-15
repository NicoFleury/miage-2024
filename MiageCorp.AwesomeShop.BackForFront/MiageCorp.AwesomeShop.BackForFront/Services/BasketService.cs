using MiageCorp.AwesomeShop.BackForFront.Models;
using RestSharp;

namespace MiageCorp.AwesomeShop.BackForFront.Services
{
    public class BasketService : IBasketService
    {
        private RestClient client;
        private const string ressourcePath = "api/baskets";


        public BasketService(IConfiguration configuration)
        {
            client = new RestClient(configuration["Api:Basket"]);
        }

        public async Task AddToBasket(string userId, Item item)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{userId}");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(item);
            var response = await client.PutAsync(request);
            if (!response.IsSuccessful)
            {
                throw new BackForFrontException(response.StatusCode, response.ErrorMessage);
            }
        }

        public async Task ClearBasket(string userId)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{userId}");
            var response = await client.DeleteAsync(request);
            if(!response.IsSuccessful)
            {
                throw new BackForFrontException(response.StatusCode, response.ErrorMessage);
            }
        }

        public async Task<List<Item>> GetBasketContent(string userId)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{userId}");
            var results = await client.GetAsync<List<Item>>(request);
            return results != null ? results : new List<Item>();
        }

        public async Task RemoveFromBasket(string userId, string itemId)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{userId}/items/{itemId}");
            var response = await client.DeleteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new BackForFrontException(response.StatusCode, response.ErrorMessage);
            }
        }
    }
}
