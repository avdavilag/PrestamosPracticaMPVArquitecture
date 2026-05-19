using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.Model.Entities
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }   
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public List<Prestamo> Prestamos { get; set; }

    }
}
