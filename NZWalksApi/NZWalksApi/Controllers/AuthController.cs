using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models.Dto;
using NZWalksApi.Repositories;

namespace NZWalksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository repository, IMapper map, ITokenHandler tokenHandler)
        {
            this.userRepository = repository;
            this.mapper = map;
            this.tokenHandler = tokenHandler;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            var user = mapper.Map<Models.Domain.User>(loginRequest);
            var userLogin = await userRepository.AuthenticateAsync(user.Username, user.Password);

            //
            if (userLogin != null)
            {
                //return Jwt token#
                var token = await tokenHandler.CreateTokenAsync(userLogin);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }
    }
}
