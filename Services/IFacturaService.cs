using SistemaInventario.Models.Dto;

namespace SistemaInventario.Services
{
    public interface IFacturaService
    {
        Task<IEnumerable<VerFacturaDto>> GetAllFacturaAsync();
        Task<VerFacturaDto> GetFacturaByIdAsync(int id);
        Task<VerFacturaDto> CreateFacturaAsync(CrearFacturaDto crearFacturaDto);
        Task<VerFacturaDto> UpdateFacturaAsync(int id, CrearFacturaDto crearFacturaDto);
        Task<VerFacturaDto> DeleteFacturaAsync(int id);
    }
}
