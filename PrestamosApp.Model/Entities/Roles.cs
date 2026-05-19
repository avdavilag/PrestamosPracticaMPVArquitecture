using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.Model.Entities
{
    public class Roles
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }=string.Empty;
        public List<Usuarios> Usuarios { get; set; } = new();
    }
}
