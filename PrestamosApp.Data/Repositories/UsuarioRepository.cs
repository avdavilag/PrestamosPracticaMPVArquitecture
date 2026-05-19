using System;
using System.Collections.Generic;
using System.Text;
using PrestamosApp.Data.Context;
using PrestamosApp.Data.Interfaces;
using PrestamosApp.Model.Entities;

namespace PrestamosApp.Data.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly PrestamosDbContext _context;
        public UsuarioRepository(PrestamosDbContext context)
        {
            _context = context;
        }

        public Usuarios? GetForMail(string email) => _context.Usuarios.FirstOrDefault(u => u.Email == email);

        public Usuarios? CreateUser(Usuarios User)
        {
            var response = _context.Usuarios.Add(User);
            _context.SaveChanges();
            return User;
        }
        public bool GetByEmail(string email) =>_context.Usuarios.Any(u => u.Email == email);
        
    }
}
