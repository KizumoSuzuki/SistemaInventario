using SistemaInventario.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Interfaces.Services
{
    public interface ICompraService
    {
        Task<IEnumerable<VerCompraDto>> GetAllComprasAsync();
        Task<VerCompraDto> GetCompraByIdAsync(int id);
        Task<VerCompraDto> CreateCompraAsync(CrearCompraDto dto);
        Task<bool> DeleteCompraAsync(int id);
    }
}
