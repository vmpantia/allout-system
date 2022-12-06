using AllOut.Api.Contractors;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

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

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (ServiceException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductByID/{id}")]
        public async Task<IActionResult> GetProductIDAsync(Guid id)
        {
            try
            {
                var response = await _product.GetProductByIDAsync(id);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (ServiceException ex)
            {
                return Conflict(ex.Message);
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
            catch (ServiceException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
