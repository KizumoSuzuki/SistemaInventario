using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaInventario.Data;
using SistemaInventario.Enums;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Login - Ingresa tu usuario y contraseña para obtener el token JWT
        /// </summary>
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginUsuarioDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Contraseña))
                return BadRequest(new { Mensaje = "El usuario y la contraseña son requeridos." });

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null || usuario.Contraseña != HashPassword(request.Contraseña))
                return Unauthorized(new { Mensaje = "Usuario o contraseña incorrectos." });

            var token = GenerateJwtToken(usuario);

            return Ok(new AuthResponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = usuario.Rol.ToString(),
                Token = token
            });
        }

        /// <summary>
        /// Registrar nuevo usuario - Solo SuperAdmin puede crear Admins. 
        /// Admin puede crear Usuarios. Rol permitido: Admin, Usuario.
        /// </summary>
        [HttpPost("Register")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult> Register([FromBody] RegisterDto request)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(request.Nombre) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Contraseña))
                return BadRequest(new { Mensaje = "Nombre, usuario y contraseña son obligatorios." });

            // No se puede registrar un SuperAdmin
            if (request.Rol == Rol.SuperAdmin)
                return Forbid();

            // Si el que registra es Admin, no puede crear otro Admin
            var rolDelRequester = User.FindFirstValue(ClaimTypes.Role);
            if (rolDelRequester == "Admin" && request.Rol == Rol.Admin)
                return StatusCode(403, new { Mensaje = "Un Admin no puede crear otros Admins. Solo el SuperAdmin puede hacerlo." });

            // Verificar que el email/usuario no exista
            var existe = await _context.Usuarios.AnyAsync(u => u.Email == request.Email);
            if (existe)
                return BadRequest(new { Mensaje = "Ya existe un usuario con ese nombre de usuario." });

            var nuevoUsuario = new Usuario
            {
                Nombre = request.Nombre,
                Email = request.Email,
                Contraseña = HashPassword(request.Contraseña),
                Telefono = request.Telefono ?? "",
                Rol = request.Rol
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Mensaje = $"Usuario '{request.Nombre}' creado exitosamente con rol {request.Rol}.",
                Id = nuevoUsuario.Id,
                Rol = nuevoUsuario.Rol.ToString()
            });
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Rol.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
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
