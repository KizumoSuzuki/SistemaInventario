using CRUD.Models;

namespace CRUD.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> CreateAsync(Producto producto);
        Task<bool> UpdateAsync(int id, Producto producto); // Asegúrate de que los parámetros coincidan
        Task<bool> DeleteAsync(int id);
    }
}