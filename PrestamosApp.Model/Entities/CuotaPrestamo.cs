

namespace PrestamosApp.Model.Entities
{
    public class CuotaPrestamo
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int NumeroCuota { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; }= string.Empty;
        public Prestamo Prestamo { get; set; }= null!;


    }
}
