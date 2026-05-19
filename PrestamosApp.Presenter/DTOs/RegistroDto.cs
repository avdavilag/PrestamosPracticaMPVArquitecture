using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.Presenter.DTOs
{
    public class RegistroDto
    {
        public string Nombre { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RolId { get; set; }
        public int? ClienteId { get; set; }  
       
    }
}
