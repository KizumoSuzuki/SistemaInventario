using SistemaInventario.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public interface IAlmacenService
    {
        Task<IEnumerable<VerAlmacenDto>> GetAllAlmacenesAsync();
        Task<VerAlmacenDto> GetAlmacenByIdAsync(int id);
        Task<VerAlmacenDto> CreateAlmacenAsync(CrearAlmacenDto dto);
        Task<VerAlmacenDto> UpdateAlmacenAsync(int id, CrearAlmacenDto dto);
        Task<bool> DeleteAlmacenAsync(int id);
    }
}
