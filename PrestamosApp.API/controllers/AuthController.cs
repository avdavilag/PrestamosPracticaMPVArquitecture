using Microsoft.AspNetCore.Mvc;
using PrestamosApp.Presenter.Services;
using PrestamosApp.Presenter.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;

namespace PrestamosApp.API.controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _authService;

        public AuthController(AuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost("registro")]
        public IActionResult Register([FromBody] RegistroDto registroDto)
        {
            try
            {
                var usuarioCreado = _authService.CreateUser(registroDto);
                return Ok(usuarioCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableRateLimiting("login")]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = _authService.Login(loginDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
