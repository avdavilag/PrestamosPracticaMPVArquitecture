using PrestamosApp.Model.Entities;


namespace PrestamosApp.Data.Interfaces;

public interface IClienteRepository
	{
		List<Cliente> ObtenerTodos();
		Cliente? ObtnerPorId(int id);
		void  Crear(Cliente cliente);
		void Actualizar(Cliente cliente);
		void Eliminar(int id);
    }