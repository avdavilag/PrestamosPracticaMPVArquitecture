using Microsoft.EntityFrameworkCore;
using PrestamosApp.Model.Entities;
using PrestamosApp.Data.Interfaces;
using PrestamosApp.Data.Context;

namespace PrestamosApp.Data.Repositories;

public class PrestamoRepository : IPrestamoRepository
{ 
    private readonly PrestamosDbContext _context;  
    
    public PrestamoRepository(PrestamosDbContext context)
    {
        _context = context;
    }

    public List<Prestamo> ObtenerTodos()
         => _context.Prestamos
            .Include(p => p.Cliente)
            .Include(p => p.TipoPrestamo)
            .Include(p=>p.Sucursales)
            .ToList();
    
    public List<Prestamo> ObtenerPorClienteId(int clienteId)
        => _context.Prestamos
            .Where(p => p.ClienteId == clienteId)
            .Include(p => p.Cliente)
            .Include(p => p.TipoPrestamo)
            .ToList();  

    public Prestamo? ObtnerPorId(int id)
        => _context.Prestamos
            .Include(p => p.Cliente)
            .Include(p => p.TipoPrestamo)
            .FirstOrDefault(p => p.Id == id);

    public void Crear(Prestamo prestamo)
    {
        _context.Prestamos.Add(prestamo);
        _context.SaveChanges();
    }
}
