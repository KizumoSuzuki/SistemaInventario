using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;


namespace SistemaInventario.Repositories
{
    public class AlmacenRepository : IAlmacenRepository
    {
        private readonly ApplicationDbContext _context;

        public AlmacenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Almacen>> GetAllAlmacenesAsync()
        {
            return await _context.Almacenes
                .Include(a => a.AlmacenProductos)
                    .ThenInclude(ap => ap.Producto)
                .ToListAsync();
        }

        public async Task<Almacen> GetAlmacenByIdAsync(int id)
        {
            return await _context.Almacenes
         .Include(a => a.AlmacenProductos)
             .ThenInclude(ap => ap.Producto) 
         .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> CreateAlmacenAsync(Almacen almacen)
        {
            _context.Almacenes.Add(almacen);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAlmacenAsync(Almacen almacen)
        {
            _context.Almacenes.Update(almacen);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAlmacenAsync(int id)
        {
            var almacen = await _context.Almacenes.FindAsync(id);
            if (almacen == null) return false;

            _context.Almacenes.Remove(almacen);
            return await _context.SaveChangesAsync() > 0;
        }

      
        public async Task<bool> AñadirProductoAlAlmacenAsync(int almacenId, int productoId, int cantidad)
        {
            
            var registroExistente = await _context.AlmacenProductos
                .FirstOrDefaultAsync(ap => ap.AlmacenId == almacenId && ap.ProductoId == productoId);

            if (registroExistente != null)
            {
                
                registroExistente.Stock += cantidad;
            }
            else
            {
                
                var nuevoRegistro = new AlmacenProducto
                {
                    AlmacenId = almacenId,
                    ProductoId = productoId,
                    Stock = cantidad
                };
                await _context.AlmacenProductos.AddAsync(nuevoRegistro);
            }

            
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
