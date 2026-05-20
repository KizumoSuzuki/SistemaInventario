using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;


namespace SistemaInventario.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. MODIFICADO: Ahora trae los productos con su Categoría y Proveedor incluidos
        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria) // Hace el JOIN en SQL con Categorías
                .Include(p => p.Proveedor) // Hace el JOIN en SQL con Proveedores
                .ToListAsync();
        }

        // 2. MODIFICADO: Cambiamos FindAsync por FirstOrDefaultAsync para poder usar .Include()
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> CreateProductoAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            // Aquí puedes dejar el FindAsync solo para validar existencia antes de borrar
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}