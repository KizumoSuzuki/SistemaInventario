

using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public class ProductoRepository: IProductoRepository 
    {
        private readonly ApplicationDbContext _context;
        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
        public async Task<bool> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;
            _context.Productos.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
