using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestamosApp.Model.Entities;
using PrestamosApp.Presenter.DTOs;
using PrestamosApp.Presenter.Services;


namespace PrestamosApp.API.controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class SucursalesController : ControllerBase
    {
        public readonly SucursalService _sucursalService;
        public SucursalesController(SucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet]
        public IActionResult ObtenerTodos() => Ok(_sucursalService.GetSucursales());


        // Debes sacar uno solo 
        [HttpGet("{id}")]
        public IActionResult ObtenerUnaSucursal(int id) => Ok(_sucursalService.ObtenerSucursalPorId(id));


        [HttpPost]
        public IActionResult CreateSucursal([FromBody] SucursalesDto sucursalDto)
        {
             try { 
                var sucursalCreado=_sucursalService.CreateSucursal(sucursalDto);
                return Ok(sucursalCreado);  

            } catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSucursal(int id,[FromBody] SucursalesDto sucursalDto)
        {
            try
            {
             var retornoSucursal= _sucursalService.UpdateSucursal(id,sucursalDto);
                return Ok(retornoSucursal);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSucursal(int id)
        {
            try
            {
                var retornoSucursal = _sucursalService.DeleteSucursal(id);
                return Ok(retornoSucursal);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
