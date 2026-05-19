using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CRUDContext _context;

        public ClienteRepository(CRUDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
            => await _context.Cliente.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id)
            => await _context.Cliente.FindAsync(id);

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(int id, Cliente cliente)
        {
            if (id != cliente.Id) return false;

            _context.Entry(cliente).State = EntityState.Modified;

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
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return false;

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Cliente.AnyAsync(e => e.Id == id);
    }
}
