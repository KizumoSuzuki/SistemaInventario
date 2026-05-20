using SistemaInventario.Models.Entities;

namespace SistemaInventario.Interfaces.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync();
        Task <Producto> GetProductoByIdAsync(int id);
        Task <bool> CreateProductoAsync(Producto producto);
        Task <bool> UpdateProductoAsync( Producto producto);
        Task <bool> DeleteProductoAsync(int id);
    }
}
