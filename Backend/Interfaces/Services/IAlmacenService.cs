using SistemaInventario.Models.Dto;


namespace SistemaInventario.Interfaces.Services
{
    public interface IAlmacenService
    {
        Task<IEnumerable<VerAlmacenDto>> GetAllAlmacenesAsync();
        Task<VerAlmacenDto> GetAlmacenByIdAsync(int id);
        Task<VerAlmacenDto> CreateAlmacenAsync(CrearAlmacenDto dto);
        Task<VerAlmacenDto> UpdateAlmacenAsync(int id, CrearAlmacenDto dto);
        Task<bool> DeleteAlmacenAsync(int id);
        Task<bool> AsignarProductoAsync(AsignarProductoAlmacenDto dto);
    }
}
