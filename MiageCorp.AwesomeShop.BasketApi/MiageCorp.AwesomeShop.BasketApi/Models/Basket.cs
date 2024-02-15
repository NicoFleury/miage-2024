namespace MiageCorp.AwesomeShop.BasketApi.Models
{
    public class Basket
    {
        public string? UserId { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
