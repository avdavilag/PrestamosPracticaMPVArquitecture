using Microsoft.AspNetCore.Mvc;
using PrestamosApp.Presenter.Services;
using PrestamosApp.Presenter.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PrestamosApp.API.controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        public readonly PrestamoService _serivice;

        public PrestamoController(PrestamoService serivice)
        {
            _serivice = serivice;
        }

       [HttpGet]
       public IActionResult ObtenerTodos()=> Ok(_serivice.ObtenerTodos());

        [HttpPost]
        public IActionResult Crear([FromBody] PrestamoDto prestamoDto)
        {
            try
            {
                var prestamoCreado = _serivice.Crear(prestamoDto);
                return Ok(prestamoCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
