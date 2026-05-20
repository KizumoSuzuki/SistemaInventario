using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly ApplicationDbContext _context;

        public CompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Compra>> GetAllComprasAsync()
        {
            return await _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Almacen)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Producto)
                .ToListAsync();
        }

        public async Task<Compra> GetCompraByIdAsync(int id)
        {
            return await _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Almacen)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CreateCompraAsync(Compra compra)
        {
            _context.Compras.Add(compra);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCompraAsync(Compra compra)
        {
            _context.Compras.Update(compra);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCompraAsync(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null) return false;

            _context.Compras.Remove(compra);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
