using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CRUDContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(CRUDContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Registrar un nuevo usuario
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] LoginDto request)
        {
            if (string.IsNullOrWhiteSpace(request.NombreUsuario) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("El nombre y la contraseña son requeridos.");
            }

            if (await _context.Usuario.AnyAsync(u => u.NombreUsuario == request.NombreUsuario))
            {
                return BadRequest("Ese nombre de usuario ya existe.");
            }

            var usuario = new Usuario
            {
                NombreUsuario = request.NombreUsuario,
                PasswordHash = HashPassword(request.Password)
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = $"Usuario '{request.NombreUsuario}' registrado exitosamente." });
        }

        /// <summary>
        /// Login - Pon tu nombre y contraseña para obtener el token
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto request)
        {
            if (string.IsNullOrWhiteSpace(request.NombreUsuario) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("El nombre y la contraseña son requeridos.");
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.NombreUsuario == request.NombreUsuario);

            if (usuario == null || usuario.PasswordHash != HashPassword(request.Password))
            {
                return Unauthorized("Nombre o contraseña incorrectos.");
            }

            var token = GenerateJwtToken(usuario.NombreUsuario);

            return Ok(new LoginResponseDto
            {
                Id = usuario.Id,
                Mensaje = $"Bienvenido {usuario.NombreUsuario}",
                Token = token
            });
        }

        /// <summary>
        /// Borrar cuenta de usuario
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Cuenta eliminada exitosamente." });
        }

        private string GenerateJwtToken(string nombre)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, nombre)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }


}
