using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<bool> CreateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;
            _context.Clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
