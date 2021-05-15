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
    [Route("/api/game-ecommerce/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<PurchaseResource>> GetAllAsync()
        {
            var purchases = await _service.ListAsync();
            var resource = _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);
            return resource;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var purchase = await _service.FindByIdAsync(id);
            if (purchase == null) return NoContent();

            var resource = _mapper.Map<Purchase, PurchaseResource>(purchase);

            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);

            var result = await _service.SaveAsync(purchase);

            if (!result.Success)
                return BadRequest();

            var purchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(purchaseResource);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);
            var result = await _service.UpdateAsync(id, purchase);

            if (!result.Success)
                return BadRequest();

            var purchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(purchaseResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(resource);
        }
    }
}
