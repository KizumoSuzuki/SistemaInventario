using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuarioAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<bool> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;

        }
    }

}
