using System.Security.Cryptography;
using System.Text;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;


namespace SistemaInventario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<VerUsuarioDto>> GetAllUsuarioAsync()
        {
            var usuarios = await _usuarioRepository.GetAllUsuarioAsync();
            return usuarios
                .Where(u => u.Rol != Enums.Rol.SuperAdmin) // Ocultar al SuperAdmin de la lista
                .Select(u => new VerUsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Telefono = u.Telefono,
                Rol = u.Rol
            });
        }

        public async Task<VerUsuarioDto> GetUsuarioByIdAsync(int id)
        {
            var u = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (u == null) return null;

            return new VerUsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Telefono = u.Telefono,
                Rol = u.Rol
            };
        }

        public async Task<VerUsuarioDto> CreateUsuarioAsync(CrearUsuarioDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Contraseña = HashPassword(dto.Contraseña),
                Telefono = dto.Telefono ?? "",
                Rol = dto.Rol
            };

            var result = await _usuarioRepository.CreateUsuarioAsync(usuario);

            if (result)
            {
                return new VerUsuarioDto
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    Rol = usuario.Rol
                };
            }

            return null;
        }

        public async Task<VerUsuarioDto> UpdateUsuarioAsync(int id, CrearUsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;

            usuario.Nombre = dto.Nombre;
            usuario.Email = dto.Email;
            usuario.Contraseña = HashPassword(dto.Contraseña);
            usuario.Rol = dto.Rol;

            var result = await _usuarioRepository.UpdateUsuarioAsync(usuario);

            if (result)
            {
                return new VerUsuarioDto
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    Rol = usuario.Rol
                };
            }

            return null;
        }

        public async Task<VerUsuarioDto> DeleteUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;

            var result = await _usuarioRepository.DeleteUsuarioAsync(id);

            if (result)
            {
                return new VerUsuarioDto
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    Rol = usuario.Rol
                };
            }

            return null;
        }

        public async Task<VerUsuarioDto> LoginAsync(LoginUsuarioDto loginDto)
        {
         
            var usuarios = await _usuarioRepository.GetAllUsuarioAsync();
            var usuario = usuarios.FirstOrDefault(u => u.Email == loginDto.Email && u.Contraseña == loginDto.Contraseña);

            if (usuario == null) return null;

            return new VerUsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Rol = usuario.Rol
            };
        }

        private static string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
