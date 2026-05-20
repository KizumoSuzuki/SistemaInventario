using SistemaInventario.Models.Entities;

namespace SistemaInventario.Interfaces.Repositories
{
    public interface IClienteRepository
    {
       Task<IEnumerable<Cliente>> GetAllClienteAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<bool> CreateClienteAsync(Cliente cliente);
        Task<bool> UpdateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync (int id);
    }
}
