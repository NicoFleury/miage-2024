using MiageCorp.AwesomeShop.BasketApi.Models;
using MiageCorp.AwesomeShop.BasketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.BasketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private IBasketService BasketService { get; set; }

        public BasketsController(IBasketService basketService)
        {
            BasketService = basketService;
        }

        // GET api/<BasketsController>/5
        [HttpGet("{userId}")]
        public List<Item> Get(string userId)
        {
            return BasketService.GetBasketContent(userId);
        }

        // PUT api/<BasketsController>/5
        [HttpPut("{userId}")]
        public void Put(string userId, [FromBody] Item item)
        {
            BasketService.AddToBasket(userId, item);
        }

        // DELETE api/<BasketsController>/5
        [HttpDelete("{userId}")]
        public void Delete(string userId)
        {
            BasketService.ClearBasket(userId);
        }

        // DELETE api/<BasketsController>/5
        [HttpDelete("{userId}/items/{itemId}")]
        public void Delete(string userId, string itemId)
        {
            BasketService.RemoveFromBasket(userId, itemId);
        }
    }
}
