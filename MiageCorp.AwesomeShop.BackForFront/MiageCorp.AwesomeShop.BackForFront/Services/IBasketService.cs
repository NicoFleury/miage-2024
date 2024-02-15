using MiageCorp.AwesomeShop.BackForFront.Models;

namespace MiageCorp.AwesomeShop.BackForFront.Services
{
    public interface IBasketService
    {
        Task AddToBasket(string userId, Item item);
        Task ClearBasket(string userId);
        Task<List<Item>> GetBasketContent(string userId);
        Task RemoveFromBasket(string userId, string itemId);
    }
}
