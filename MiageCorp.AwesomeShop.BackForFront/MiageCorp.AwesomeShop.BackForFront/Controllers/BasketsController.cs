using MiageCorp.AwesomeShop.BackForFront.Models;
using MiageCorp.AwesomeShop.BackForFront.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.BackForFront.Controllers
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
        public async Task<List<Item>> Get(string userId)
        {
            return await BasketService.GetBasketContent(userId);
        }

        // PUT api/<BasketsController>/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(string userId, [FromBody] Item item)
        {
            try
            {
                await BasketService.AddToBasket(userId, item);
                return Ok();
            }
            catch (BackForFrontException ex) 
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }        
        }

        // DELETE api/<BasketsController>/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                await BasketService.ClearBasket(userId);
                return Ok();
            }
            catch (BackForFrontException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

        // DELETE api/<BasketsController>/5
        [HttpDelete("{userId}/items/{itemId}")]
        public async Task<IActionResult> Delete(string userId, string itemId)
        {
            try
            {
                await BasketService.RemoveFromBasket(userId, itemId);
                return Ok();
            }
            catch (BackForFrontException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
}
