using PrestamosApp.Model.Entities;

namespace PrestamosApp.Data.Interfaces;


public interface ITipoPrestamoRepository
{
public List<TipoPrestamo> ObtenerTodos();
 public	TipoPrestamo? ObtenerPorEdad(int edad);
}
