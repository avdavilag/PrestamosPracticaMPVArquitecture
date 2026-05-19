using PrestamosApp.Model.Entities;
using PrestamosApp.Data.Interfaces;
using PrestamosApp.Presenter.DTOs;

namespace PrestamosApp.Presenter.Services
{
    public  class PrestamoService
    {
        private  readonly IPrestamoRepository _prestamoRepo;
        private readonly IClienteRepository _clienteRepo;
        private readonly ITipoPrestamoRepository _tipoRepo;

        public PrestamoService(
            IPrestamoRepository prestamoRepo,
            IClienteRepository clienteRepo, 
            ITipoPrestamoRepository tipoRepo)
        {
            _prestamoRepo = prestamoRepo;
            _clienteRepo = clienteRepo;
            _tipoRepo = tipoRepo;
        }

        public List<PrestamoResponseDto> ObtenerTodos()
        {
            return _prestamoRepo.ObtenerTodos().Select(p => new PrestamoResponseDto
            {
                Id = p.Id,
                NombreCliente = $"{p.Cliente.Nombre} {p.Cliente.Apellido}",
                TipoPrestamo = p.TipoPrestamo.Nombre,
                Monto = p.Monto,
                Estado = p.Estado,
                NombreSucursal=p.Sucursales.Nombre,
                FechaCreacion = p.FechaCreacion
            }).ToList();
            }
        
        public PrestamoResponseDto Crear(PrestamoDto dto)
        {
            // Buscar el cliente
            var cliente = _clienteRepo.ObtnerPorId(dto.ClienteId)
            ?? throw new Exception("Cliente no encontrado");

            // Buscador segun la edad.
            var tipo = _tipoRepo.ObtenerPorEdad(cliente.Edad) ?? throw new Exception("No hay un tipo de préstamo adecuado para la edad del cliente");

            var prestamo = new Prestamo
            {
                ClienteId = dto.ClienteId,
                TipoPrestamoId = tipo.Id,
                Monto = dto.Monto
            };  

            _prestamoRepo.Crear(prestamo);

            return new PrestamoResponseDto
            {
                Id = prestamo.Id,
                NombreCliente = $"{cliente.Nombre} {cliente.Apellido}",
                TipoPrestamo = tipo.Nombre,
                Monto = prestamo.Monto,
                Estado = prestamo.Estado,
                FechaCreacion = prestamo.FechaCreacion
            };
        }
               
    }
}
