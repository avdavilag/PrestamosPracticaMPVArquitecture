using PrestamosApp.Data.Interfaces;
using PrestamosApp.Data.Context;
using PrestamosApp.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace PrestamosApp.Data.Repositories
{
    public class SucursalesRepository : ISucursales
    {
        private readonly PrestamosDbContext _context;

        public SucursalesRepository(PrestamosDbContext context)
        {
            _context = context;
        }

        public List<Sucursales> GetSucursales() => _context.Sucursales.ToList();

        public Sucursales ObtenerUnaSucursal (int Id) => _context.Sucursales.Find(Id);
        public void CreateSucursales(Sucursales sucursal)
        {
            _context.Sucursales.Add(sucursal);
            _context.SaveChanges();
        }

        public Sucursales UpdateSucursales(Sucursales sucursales)
        {
            _context.Sucursales.Update(sucursales);
            _context.SaveChanges();

            return sucursales;
        }

        public bool DeleteSucursal(int id)
        {
           return _context.Sucursales.Where(s => s.Id == id).ExecuteDelete() > 0;
         
        }
    }

}
