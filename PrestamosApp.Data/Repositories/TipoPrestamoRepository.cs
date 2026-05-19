using PrestamosApp.Data.Interfaces;    
using PrestamosApp.Data.Context;


namespace PrestamosApp.Data.Repositories
{
    public class TipoPrestamoRepository : ITipoPrestamoRepository
        {
        private readonly PrestamosDbContext _context;
        public TipoPrestamoRepository(PrestamosDbContext context)
        {
            _context = context;
        }
        public List<TipoPrestamo> ObtenerTodos()
           => _context.TipoPrestamo.ToList();
        
        public TipoPrestamo? ObtenerPorEdad(int edad)
        {
            return _context.TipoPrestamo.FirstOrDefault(tp => tp.EdadMinima <= edad && tp.EdadMaxima >= edad);
        }
    
    }
}
