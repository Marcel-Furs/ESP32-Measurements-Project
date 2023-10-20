using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomiaryEsp32.Data.Models;
using PomiaryEsp32.Data.Repositories;
using PomiaryEsp32.Dto;
using PomiaryEsp32.Exceptions;
using PomiaryEsp32.Services;

namespace PomiaryEsp32.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AuthController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDto);
                await userService.CreateUser(user, userDto.Password);
                return Ok();
            }

            return BadRequest("Invalid body data");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userService.Authorize(userDto.Username, userDto.Password);
                    return Ok(new { Token = tokenService.CreateToken(user.Id.ToString(), user.Username) });
                }
                catch (InvalidCredentialsException ex)
                {
                    return Unauthorized(ex.Message);
                }
            }

            return BadRequest("Invalid body data");
        }
    }
}
