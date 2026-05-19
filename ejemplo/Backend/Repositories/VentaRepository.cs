using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly CRUDContext _context;

        public VentaRepository(CRUDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ventas>> GetAllAsync()
            => await _context.Ventas.ToListAsync();

        public async Task<Ventas?> GetByIdAsync(int id)
            => await _context.Ventas.FindAsync(id);

        public async Task<Ventas> CreateAsync(Ventas venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task<bool> UpdateAsync(int id, Ventas venta)
        {
            if (id != venta.Id) return false;

            _context.Entry(venta).State = EntityState.Modified;

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
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null) return false;

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Ventas.AnyAsync(e => e.Id == id);
    }
}
