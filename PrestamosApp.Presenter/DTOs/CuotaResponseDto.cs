using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Presenter.DTOs
{
    public class CuotaResponseDto
    {
        public int Id { get; set; }
        public int NumeroCuota{ get; set; }
        public int MontoCuota { get; set; }
        public int Capital { get; set; }
        public int Interes { get; set; }
        public int Saldo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; } = string.Empty;

    }
}
