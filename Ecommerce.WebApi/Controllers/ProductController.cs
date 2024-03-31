using Business.Abstract;
using Ecommerce.WebApi.Helpers;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromForm] ProductCreateOrUpdateDto dto, IFormFile photoUrl)
        {
            dto.PhotoUrl = ImageHelper.SaveFile(photoUrl);

            var result = _productService.Add(dto);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] ProductCreateOrUpdateDto dto, IFormFile photoUrl)
        {
            if (photoUrl != null)
                dto.PhotoUrl = ImageHelper.SaveFile(photoUrl);

            var result = _productService.Update(dto);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
