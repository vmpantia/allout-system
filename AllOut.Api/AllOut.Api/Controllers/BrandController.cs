using AllOut.Api.Contractors;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AllOut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _Brand;
        public BrandController(IBrandService Brand)
        {   
            _Brand = Brand;
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrandsAsync()
        {
            try
            {
                var response = await _Brand.GetBrandsAsync();
                return Ok(response);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBrandByID/{id}")]
        public async Task<IActionResult> GetBrandIDAsync(Guid id)
        {
            try
            {
                var response = await _Brand.GetBrandByIDAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveBrand")]
        public async Task<IActionResult> SaveBrandAsync(BrandRequest request)
        {
            try
            {
                var response = await _Brand.SaveBrandAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
