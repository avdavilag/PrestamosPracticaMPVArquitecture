using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.Model.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RolId { get; set; }

        public Roles Rol { get; set; }
        public Cliente Cliente { get; set; }
        public int? ClienteId { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
