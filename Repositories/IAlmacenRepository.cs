using SistemaInventario.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Repositories
{
    public interface IAlmacenRepository
    {
        Task<IEnumerable<Almacen>> GetAllAlmacenesAsync();
        Task<Almacen> GetAlmacenByIdAsync(int id);
        Task<bool> CreateAlmacenAsync(Almacen almacen);
        Task<bool> UpdateAlmacenAsync(Almacen almacen);
        Task<bool> DeleteAlmacenAsync(int id);
    }
}
