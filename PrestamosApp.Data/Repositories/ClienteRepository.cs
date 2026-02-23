using PrestamosApp.Model.Entities;
using PrestamosApp.Model.Interfaces;
using PrestamosApp.Data.Context;


namespace PrestamosApp.Data.Repositories;

public class ClienteRepository : IClienteRepository
{
	private readonly PrestamosDbContext _context;

	public ClienteRepository(PrestamosDbContext context)
	{
		_context = context;
	}

	public List<Cliente> ObtenerTodos()
	{
		return _context.Clientes.ToList();
	}

	public Cliente? ObtnerPorId(int id)
	{
		return _context.Clientes.Find(id);
	}

	public void Crear(Cliente cliente)
	{
		_context.Clientes.Add(cliente);
		_context.SaveChanges();
	}

	public void Actualizar(Cliente cliente)
	{
		_context.Clientes.Update(cliente);
		_context.SaveChanges();
	}

	public void Eliminar(int id)
	{
		var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
		if (cliente != null)
		{
			_context.Clientes.Remove(cliente);
			_context.SaveChanges();
        }
    }
}
