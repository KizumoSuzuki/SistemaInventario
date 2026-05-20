using SistemaInventario.Models.Entities;


namespace SistemaInventario.Interfaces.Repositories
{
    public interface IAlmacenRepository
    {
        Task<IEnumerable<Almacen>> GetAllAlmacenesAsync();
        Task<Almacen> GetAlmacenByIdAsync(int id);
        Task<bool> CreateAlmacenAsync(Almacen almacen);
        
        Task<bool> UpdateAlmacenAsync(Almacen almacen);
        Task<bool> DeleteAlmacenAsync(int id);
        Task<bool> AñadirProductoAlAlmacenAsync(int almacenId, int productoId, int cantidad);
    }
}
