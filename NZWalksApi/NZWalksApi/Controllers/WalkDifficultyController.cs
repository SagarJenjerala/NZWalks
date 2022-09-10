using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models.Dto;
using NZWalksApi.Repositories;

namespace NZWalksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository repository;
        public readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper map)
        {
            this.repository = walkDifficultyRepository;
            mapper = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await repository.GetWalkDifficultiesAsync();
            var dto = mapper.Map<List<Models.Dto.WalkDifficulty>>(result);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await repository.GetWalkDifficultByIdAsync(Id);
            if (result is null)
            {
                return NotFound();
            }

            var dto = mapper.Map<Models.Dto.WalkDifficulty>(result);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddWalkDifficulty addWalkDifficulty)
        {
            var domainModel = mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficulty);
            var result = await repository.AddWalkDifficultiAsync(domainModel);
            var resultDto = mapper.Map<Models.Dto.WalkDifficulty>(result);
            return CreatedAtAction(nameof(GetByIdAsync), new { Id = resultDto.Id }, resultDto);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid Id, [FromBody] UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            var updateWalkDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequest);

            var result = await repository.UpdateWalkDifficultyAsync(Id, updateWalkDifficulty);

            if (result is null)
            {
                return NotFound();
            }

            var resultDto = mapper.Map<Models.Dto.WalkDifficulty>(result);
            return Ok(resultDto);
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid Id)
        {
            var deleted = await repository.DeleteAsync(Id);
            if (deleted is null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Models.Dto.WalkDifficulty>(deleted));
        }
    }
}
