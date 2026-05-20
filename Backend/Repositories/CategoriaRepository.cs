using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categoria>> GetAllCategoriaAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }
        public async Task<bool> CreateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return false;
            _context.Categorias.Remove(categoria);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
