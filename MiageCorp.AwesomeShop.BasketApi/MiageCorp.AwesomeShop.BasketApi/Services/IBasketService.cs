using MiageCorp.AwesomeShop.BasketApi.Models;

namespace MiageCorp.AwesomeShop.BasketApi.Services
{
    public interface IBasketService
    {
        void AddToBasket(string userId, Item item);
        void ClearBasket(string userId);
        List<Item> GetBasketContent(string userId);
        void RemoveFromBasket(string userId, string itemId);
    }
}