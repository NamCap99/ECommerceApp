using Microsoft.AspNetCore.Mvc;                                // ControllerBase, ApiController, Route, HttpPost, IActionResult, FromBody
using E_Commerce.Application.Interfaces;                       // IAuthService
using E_Commerce.Application.DTOs.UserDTO;                     // RegisterRequestDto, LoginRequestDto, AuthResponseDto


namespace E_Commerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
    }

}
