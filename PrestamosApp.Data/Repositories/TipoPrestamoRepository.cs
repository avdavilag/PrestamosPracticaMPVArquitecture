using PrestamosApp.Model.Entities;
using PrestamosApp.Model.Interfaces;    
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
           => _context.TiposPrestamo.ToList();
        
        public TipoPrestamo? ObtenerPrestamo(int edad)
        {
            return _context.TiposPrestamo.FirstOrDefault(tp => tp.EdadMinima <= edad && tp.EdadMaxima >= edad);
        }
    
    }
}
