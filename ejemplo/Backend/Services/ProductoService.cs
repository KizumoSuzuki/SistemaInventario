using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Producto>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Producto?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<Producto> CreateAsync(Producto producto)
            => _repo.CreateAsync(producto);

        public Task<bool> UpdateAsync(int id, Producto producto)
            => _repo.UpdateAsync(id, producto);

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repo.ExistsAsync(id);
    }
}
