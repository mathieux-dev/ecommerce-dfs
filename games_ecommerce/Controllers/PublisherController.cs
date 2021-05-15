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
    [Route("/api/ecommerce/publishers")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _service;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PublisherResource>> GetAllAsync()
        {
            var publishers = await _service.ListAsync();
            var resource = _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherResource>>(publishers);
            return resource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var publisher = await _service.FindByIdAsync(id);
            if (publisher == null) return NoContent();
            var resource = _mapper.Map<Publisher, PublisherResource>(publisher);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePublisherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publisher = _mapper.Map<SavePublisherResource, Publisher>(resource);

            var result = await _service.SaveAsync(publisher);

            if (!result.Success)
                return BadRequest();

            var userResource = _mapper.Map<Publisher, PublisherResource>(result.Publisher);

            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePublisherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publisher = _mapper.Map<SavePublisherResource, Publisher>(resource);
            var result = await _service.UpdateAsync(id, publisher);

            if (!result.Success)
                return BadRequest();

            var publisherResource = _mapper.Map<Publisher, PublisherResource>(result.Publisher);

            return Ok(publisherResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<Publisher, PublisherResource>(result.Publisher);

            return Ok(resource);
        }
    }
}