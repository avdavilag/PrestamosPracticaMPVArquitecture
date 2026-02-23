using PrestamosApp.Model.Entities;
using PrestamosApp.Presenter.DTOs;
using PrestamosApp.Data.Interfaces;

namespace PrestamosApp.Presenter.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }   

        public List<Cliente> ObtenerTodos()=> _clienteRepository.ObtenerTodos();
        public Cliente? ObtenerPorId(int id) => _clienteRepository.ObtnerPorId(id);

        public Cliente? Crear(ClienteDto dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Edad = dto.Edad
            };
            _clienteRepository.Crear(cliente);
            return cliente;
        }

        public void Eliminar(int id)=>_clienteRepository.Eliminar(id);  



        public void Actualizar(int id, ClienteDto clienteDto)
        {
            var clienteExistente = _clienteRepository.ObtnerPorId(id);
            if (clienteExistente != null)
            {
                clienteExistente.Nombre = clienteDto.Nombre;
                clienteExistente.Apellido = clienteDto.Apellido;
                clienteExistente.Edad = clienteDto.Edad;
                 _clienteRepository.Actualizar(clienteExistente);
            }
        }   
    }
}
