using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using FavorisApiSecure.Data;
using FavorisApiSecure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System;

namespace FavorisApiSecure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<Utilisateur> _hasher = new();

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(Utilisateur user)
        {
            if (_context.Utilisateurs.Any(u => u.Email == user.Email))
                return BadRequest("Email déjà utilisé");

            user.PasswordHash = _hasher.HashPassword(user, user.PasswordHash);
            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto creds)
        {
            var user = _context.Utilisateurs.SingleOrDefault(u => u.Email == creds.Email);
            if (user == null) return Unauthorized();

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, creds.Password);
            if (result == PasswordVerificationResult.Failed) return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}