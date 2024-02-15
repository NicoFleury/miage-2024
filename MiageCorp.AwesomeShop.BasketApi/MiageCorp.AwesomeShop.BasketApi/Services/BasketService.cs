using MiageCorp.AwesomeShop.BasketApi.Models;

namespace MiageCorp.AwesomeShop.BasketApi.Services
{
    public class BasketService : IBasketService
    {
        private static List<Basket> _basketList = new List<Basket>();

        public List<Item> GetBasketContent(string userId)
        {
            var basket = _basketList.SingleOrDefault(b => b.UserId == userId);
            if (basket == null)
                return new List<Item>();

            return basket.Items;
        }

        public void AddToBasket(string userId, Item item)
        {
            var basket = _basketList.SingleOrDefault(b => b.UserId == userId);
            if (basket == null)
            {
                basket = new Basket()
                {
                    UserId = userId
                };
                _basketList.Add(basket);

            }
            var basketItem = basket.Items.SingleOrDefault(i => i.ProductId == item.ProductId);
            if(basketItem == null)
            {
                item.Quantity++;
                basket.Items.Add(item);
                return;
            }
            basketItem.Quantity++;


        }

        public void RemoveFromBasket(string userId, string itemId)
        {
            var basket = _basketList.SingleOrDefault(b => b.UserId == userId);
            if (basket != null)
            {
                var item = basket.Items.FirstOrDefault(i => i.ProductId == itemId);
                basket.Items.Remove(item);
            }
        }

        public void ClearBasket(string userId)
        {
            var basket = _basketList.SingleOrDefault(b => b.UserId == userId);
            if (basket != null)
            {
                basket.Items.Clear();
            }
        }
    }
}
