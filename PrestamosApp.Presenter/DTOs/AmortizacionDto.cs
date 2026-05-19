using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Presenter.DTOs
{
    public class AmortizacionDto
    {
        public int PrestamoId { get; set; }
        public int numeroCuota { get; set; }
        public decimal TasaInteres { get; set; }
    }
}
