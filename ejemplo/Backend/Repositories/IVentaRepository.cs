using CRUD.Models;

namespace CRUD.Repositories
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Ventas>> GetAllAsync();
        Task<Ventas?> GetByIdAsync(int id);
        Task<Ventas> CreateAsync(Ventas venta);
        Task<bool> UpdateAsync(int id, Ventas venta);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
