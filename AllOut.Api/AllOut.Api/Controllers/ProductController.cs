using AllOut.Api.Contractors;
using AllOut.Api.Models;
using AllOut.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllOut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var response = await _product.GetProductsAsync();
                return Ok(response);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProductAsync(ProductRequest request)
        {
            try
            {
                var response = await _product.SaveProductAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
