using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.Presenter.DTOs
{
    public class PrestamoResponseDto
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }=string.Empty;
        public string TipoPrestamo { get; set; }=string.Empty;
        public decimal Monto { get; set; }
        public string Estado { get; set; }=string.Empty; 
        public DateTime FechaCreacion { get; set; }
    }
}
