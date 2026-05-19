using CRUD.Models;

namespace CRUD.Services
{
    public interface IVentaService
    {
        Task<IEnumerable<Ventas>> GetAllAsync();
        Task<Ventas?> GetByIdAsync(int id);
        Task<VentaResponseDto> CreateAsync(VentaCreateDto dto);
        Task<bool> UpdateAsync(int id, Ventas venta);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
