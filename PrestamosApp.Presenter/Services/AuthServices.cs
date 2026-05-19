using Microsoft.Extensions.Configuration;
using PrestamosApp.Data.Interfaces;
using PrestamosApp.Data.Repositories;
using PrestamosApp.Model.Entities;
using PrestamosApp.Presenter.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace PrestamosApp.Presenter.Services
{
    public class AuthServices
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IConfiguration _configuration;

        public AuthServices(IUsuarioRepository usuarioRepo, IConfiguration configuration)
        {
            _usuarioRepo = usuarioRepo;
            _configuration = configuration;
        }

        public Usuarios? GetForMail(string email) => _usuarioRepo.GetForMail(email);
        public Usuarios? CreateUser(RegistroDto _registroDto)
        {
             if(_usuarioRepo.GetByEmail(_registroDto.Email))
                throw new Exception("This Email at exists Create");


            var usuario = new Usuarios
            {
                Nombre = _registroDto.Nombre,
                Email = _registroDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(_registroDto.PasswordHash),
                RolId = _registroDto.RolId,
                ClienteId = _registroDto.ClienteId ?? 0
               // FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd")
            };
            _usuarioRepo.CreateUser(usuario);
            return usuario;
        }

        public bool GetByEmail(string email) => _usuarioRepo.GetByEmail(email);
       
        public Usuarios? ValidateUser(LoginDto loginDto)
        {
            var user = _usuarioRepo.GetForMail(loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return null;
            return user;
        }

        public string Login(LoginDto loginDto)
        {
            var user = ValidateUser(loginDto);
            if (user == null)
                throw new Exception("Invalid email or password");
                  return GenerateJwtToken(user);
        }


        public string GenerateJwtToken(Usuarios user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RolId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }   

    }

}
