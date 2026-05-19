using PrestamosApp.Model.Entities;

namespace PrestamosApp.Data.Repositories
{
    public interface ICuotaRepository
    {
       public List<CuotaPrestamo>GetCuotasByPrestamoIdAsync(int prestamoId);

        public CuotaPrestamo? GetCuotaByIdAsync(int id);
        public void GenerarTablaAmortizacion(int prestamoId,int numeroCuota,decimal tasaInteres);   
        public void RegistrarPago(int cuotaId);

    }
}
