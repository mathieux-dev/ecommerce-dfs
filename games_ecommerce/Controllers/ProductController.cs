using AutoMapper;
using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Services;
using games_ecommerce.Extensions;
using games_ecommerce.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Controllers
{
    [Route("/api/game-ecommerce/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _service.ListAsync();
            var resource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resource;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _service.FindByIdAsync(id);
            if (product == null) return NoContent();
            var resource = _mapper.Map<Product, ProductResource>(product);
            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _service.SaveAsync(product);

            if (!result.Success)
                return BadRequest();

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _service.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest();

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NotFound();

            var resource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(resource);
        }
    }
}
