using SistemaInventario.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Repositories
{
    public interface ICompraRepository
    {
        Task<IEnumerable<Compra>> GetAllComprasAsync();
        Task<Compra> GetCompraByIdAsync(int id);
        Task<bool> CreateCompraAsync(Compra compra);
        Task<bool> UpdateCompraAsync(Compra compra);
        Task<bool> DeleteCompraAsync(int id);
    }
}
