using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CRUDContext _context;

        public ProductoRepository(CRUDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
            => await _context.Producto.ToListAsync();

        public async Task<Producto?> GetByIdAsync(int id)
            => await _context.Producto.FindAsync(id);

        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> UpdateAsync(int id, Producto producto)
        {
            if (id != producto.Id) return false;

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                    return false;
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null) return false;

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Producto.AnyAsync(e => e.Id == id);
    }
}

