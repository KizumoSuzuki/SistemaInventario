using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Cliente>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Cliente?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<Cliente> CreateAsync(Cliente cliente)
            => _repo.CreateAsync(cliente);

        public Task<bool> UpdateAsync(int id, Cliente cliente)
            => _repo.UpdateAsync(id, cliente);

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repo.ExistsAsync(id);
    }
}

