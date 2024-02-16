using MiageCorp.AwesomeShop.ProductApi.Exceptions;
using MiageCorp.AwesomeShop.ProductApi.Models;
using MiageCorp.AwesomeShop.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService ProductService { get; set; }

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            return ProductService.GetProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(string id)
        {
            var product = ProductService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var result = ProductService.AddProduct(product);
            return Created(Url.RouteUrl("GetProduct", new { id = result.Id }), result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Product product)
        {
            try
            {
                ProductService.UpdateProduct(id, product);
                return Ok();

            }
            catch (UnkownProductException)
            {
                return NotFound();
            }        
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            ProductService.DeleteProduct(id);
            return Ok();
        }
    }
}
