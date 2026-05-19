using Microsoft.AspNetCore.Authorization;   
using Microsoft.AspNetCore.Mvc;
using PrestamosApp.Presenter.DTOs;
using PrestamosApp.Presenter.Services;


namespace PrestamosApp.API.controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CuotasController : ControllerBase
    {
        public readonly CuotaService _service;
        public CuotasController(CuotaService service)
        {
            _service = service;
        }

        [HttpPost("prestamo/{id}")]
        public IActionResult GetCuotasByPrestamoIdAsync(int id)=>
            Ok(_service.GetCuotasByPrestamoIdAsync(id));

        [HttpPost("{id}")]
        public IActionResult GetCuotaByIdAsync(int id) =>
            Ok(_service.GetCuotaByIdAsync(id));


        [HttpPost("generar")]
         public IActionResult GenerarTablaAmortizacion([FromBody] AmortizacionDto dto)
        {
            try
            {
                _service.GenerarTablaAmortizacion(dto.PrestamoId, dto.numeroCuota, dto.TasaInteres);
                var cuotas = _service.GetCuotasByPrestamoIdAsync(dto.PrestamoId);
                return Ok(cuotas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("pagar/{cuotaId}")]
        public IActionResult RegistrarPago(int cuotaId)
        {
            try
            {
                _service.RegistrarPago(cuotaId);
                return Ok("Pago registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       
    }
}
