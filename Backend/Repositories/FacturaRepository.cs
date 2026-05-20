using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAllFacturaAsync()
        {
            return await _context.Facturas
                .Include(f => f.Cliente)                    
                .Include(f => f.Detalles)                   
                    .ThenInclude(d => d.Producto)            
                .ToListAsync();
        }

        public async Task<Factura> GetFacturaByIdAsync(int id)
        {
            return await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> CreateFacturaAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFacturaAsync(int id, Factura factura)
        {
            _context.Facturas.Update(factura);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFacturaAsync(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null) return false;

            _context.Facturas.Remove(factura);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
