using System;
using System.Collections.Generic;
using System.Text;
using PrestamosApp.Model.Entities;

namespace PrestamosApp.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuarios? GetForMail(string email); 
        public Usuarios? CreateUser(Usuarios usuario);
        public bool GetByEmail(string email);
    }
}
