using PrestamosApp.Model.Entities;

namespace PrestamosApp.Data.Interfaces;

public interface IPrestamoRepository
{
	List<Prestamo> ObtenerTodos();
	List<Prestamo>ObtenerPorClienteId(int clienteId);
    Prestamo? ObtnerPorId(int id);
	void Crear(Prestamo prestamo);
}
