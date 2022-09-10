using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NZWalksApi.Models.Dto;
using NZWalksApi.Repositories;

namespace NZWalksApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository repository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository _repository, IMapper _mapper)
        {
            this.repository = _repository;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resultDto = mapper.Map<List<Models.Dto.Walk>>(result);
            return Ok(resultDto);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid Id)
        {
            var result = await repository.GetAsync(Id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.Dto.Walk>(result));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddWalkRequest addWalkRequest)
        {
            var result = mapper.Map<Models.Domain.Walk>(addWalkRequest);
            await repository.AddAsync(result);
            var resultDto = mapper.Map<Models.Dto.Walk>(result);
            return CreatedAtAction(nameof(GetWalkAsync), new { Id = resultDto.Id }, resultDto);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid Id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            var request = mapper.Map<Models.Domain.Walk>(updateWalkRequest);
            var result = await repository.UpdateAsync(Id, request);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.Dto.Walk>(result));
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid Id)
        {
            var deleted = await repository.DeleteAsync(Id);
            if(deleted is null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Models.Dto.Walk>(deleted));
        }
    }
}
