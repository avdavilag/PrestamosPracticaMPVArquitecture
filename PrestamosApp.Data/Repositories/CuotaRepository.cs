using PrestamosApp.Model.Entities;
using PrestamosApp.Data.Interfaces;
using PrestamosApp.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace PrestamosApp.Data.Repositories
{
    public class CuotaRepository : ICuotaRepository
    {
        public readonly PrestamosDbContext _context;

        public CuotaRepository(PrestamosDbContext context)
        {
            _context = context;
        }

        public List<CuotaPrestamo> GetCuotasByPrestamoIdAsync(int prestamoId) => _context.CuotaPrestamos.Where(c => c.PrestamoId == prestamoId).ToList();
     

        public CuotaPrestamo? GetCuotaByIdAsync(int id) => _context.CuotaPrestamos.Find(id);

        public void GenerarTablaAmortizacion(int prestamoId, int numeroCuota, decimal tasaInteres)
         => _context.Database.ExecuteSqlRaw("EXEC SP_GenerarAmortizacion @p0,@p1,@p2", prestamoId, numeroCuota, tasaInteres);          
        public void RegistrarPago(int cuotaId)
        {
            var cuota = _context.CuotaPrestamos.FirstOrDefault(c => c.Id==cuotaId);  
            if(cuota != null) { 
               cuota.Estado = "Pagada";
                cuota.FechaPago = DateTime.Now;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Lo siento cuota no encotrada");
            }
           
        }


        //public Sucursales UpdateSucursales(Sucursales sucursales)
        //{
        //    _context.Sucursales.Update(sucursales);
        //    _context.SaveChanges();

        //    return sucursales;
        //}

        //void GenerarTablaAmortizacion(int prestamoId, int numeroCuota, decimal tasaInteres);
        //void RegistrarPago(int cuotaId);




        //List<CuotaPrestamo> GetCuotasByPrestamoIdAsync(int prestamoId);

        //CuotaPrestamo? GetCuotaByIdAsync(int id);
        //void GenerarTablaAmortizacion(int prestamoId, int numeroCuota, decimal tasaInteres);
        //void RegistrarPago(int cuotaId);
    }
}
