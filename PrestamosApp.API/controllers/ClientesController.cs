using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestamosApp.Presenter.DTOs;
using PrestamosApp.Presenter.Services;  

namespace PrestamosApp.API.controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController: ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
            => Ok(_clienteService.ObtenerTodos());

        [HttpGet ("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var cliente = _clienteService.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Crear(ClienteDto clienteDto)
        {
            var clienteCreado = _clienteService.Crear(clienteDto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = clienteCreado.Id }, clienteCreado);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            _clienteService.Eliminar(id);
            return NoContent();
        }
    }
}
