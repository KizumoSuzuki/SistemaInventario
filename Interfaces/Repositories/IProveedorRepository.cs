using SistemaInventario.Models.Entities;

namespace SistemaInventario.Interfaces.Repositories
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetAllProveedorAsync();
        Task<Proveedor> GetProveedorByIdAsync(int id);
        Task<bool> CreateProveedorAsync(Proveedor proveedor);
        Task<bool> UpdateProveedorAsync(Proveedor proveedor);
        Task <bool> DeleteProveedorAsync(int id);
    }
}
