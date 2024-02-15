using MiageCorp.AwesomeShop.BackForFront.Models;
using MiageCorp.AwesomeShop.BackForFront.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.BackForFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService ProductService { get; set; }

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await ProductService.GetProducts());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await ProductService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product model)
        {
            try
            {
                var result = await ProductService.AddProduct(model);
                return Created(Url.RouteUrl("GetProduct", new { id = result.Id }), result);
            }
            catch (BackForFrontException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product model)
        {
            try
            {
                await ProductService.UpdateProduct(id, model);
                return Ok();
            }
            catch (BackForFrontException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await ProductService.DeleteProduct(id);
                return Ok();
            }
            catch (BackForFrontException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
}
