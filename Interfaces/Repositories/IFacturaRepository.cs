using SistemaInventario.Models.Entities;

namespace SistemaInventario.Interfaces.Repositories
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllFacturaAsync();
        Task<Factura> GetFacturaByIdAsync(int id);
        Task <bool> CreateFacturaAsync(Factura factura);
        Task<bool> UpdateFacturaAsync(int id, Factura factura);
        Task<bool> DeleteFacturaAsync(int id);

    }
}
