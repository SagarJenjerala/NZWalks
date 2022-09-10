using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.Dto;
using NZWalksApi.Repositories;
using System.Text.RegularExpressions;
using Region = NZWalksApi.Models.Dto.Region;

namespace NZWalksApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepositoty;
        private readonly IMapper mapper;
        public RegionsController(IRegionRepository repositoty, IMapper map)
        {
            regionRepositoty = repositoty;
            mapper = map;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepositoty.GetAllAsync();
            var regionsDTo = mapper.Map<List<Models.Dto.Region>>(regions);

            return Ok(regionsDTo);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepositoty.GetAsync(id);

            if (region is null)
            {
                return NotFound("Region Not Found");
            }

            var regionDTo = mapper.Map<Models.Dto.Region>(region);
            return Ok(regionDTo);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddRegionRequest addRegionRequest)
        {
            var region = mapper.Map<Models.Domain.Region>(addRegionRequest);
            var newRegion = await regionRepositoty.AddAsync(region);
            var resultDto = mapper.Map<Models.Dto.Region>(newRegion);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = resultDto.Id }, resultDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // Get region from DB
            var region = await regionRepositoty.GetAsync(id);

            // not found
            if (region is null)
            {
                return NotFound("region not found");
            }

            //delete
            var deletedRegion = await regionRepositoty.DeleteAsync(id);

            // reponse to DTO
            var regionDTo = mapper.Map<Models.Dto.Region>(region);

            //Ok
            return Ok(regionDTo);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid Id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            var updateRegion = mapper.Map<Models.Domain.Region>(updateRegionRequest);

            var result = await regionRepositoty.UpdateAsync(Id, updateRegion);

            if (result is null)
            {
                return NotFound();
            }

            var resultDto = mapper.Map<Models.Dto.Region>(result);
            return Ok(resultDto);
        }
    }
}
