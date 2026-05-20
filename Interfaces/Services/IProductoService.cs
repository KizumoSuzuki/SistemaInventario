using SistemaInventario.Models.Dto;

namespace SistemaInventario.Interfaces.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<VerProductoDto>> GetAllProductoAsync();
        Task<VerProductoDto> GetProductoByIdAsync(int id);
        Task<VerProductoDto> CreateProductoAsync(CrearProductoDto crearProductoDto);
        Task<VerProductoDto> UpdateProductoAsync(int id, CrearProductoDto crearProductoDto);
        Task<bool> DeleteProductoAsync(int id);
        Task<bool> ActualizarStockAsync(int productoid, int cantidad);
    }
}