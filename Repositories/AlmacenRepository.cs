using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await _context.Almacenes.ToListAsync();
        }

        public async Task<Almacen> GetAlmacenByIdAsync(int id)
        {
            return await _context.Almacenes.FindAsync(id);
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
    }
}
