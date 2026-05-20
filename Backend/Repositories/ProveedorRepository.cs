using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProveedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<IEnumerable<Proveedor>> GetAllProveedorAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }
        public async Task<Proveedor> GetProveedorByIdAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }
        public async Task<bool> CreateProveedorAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateProveedorAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteProveedorAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return false;
            _context.Proveedores.Remove(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
