using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;
using NZWalksApi.Repositories;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepositoty.GetAllAsync();
            var regionsDTo = mapper.Map<List<Models.Dto.Region>>(regions);

            return Ok(regionsDTo);
        }
    }
}
