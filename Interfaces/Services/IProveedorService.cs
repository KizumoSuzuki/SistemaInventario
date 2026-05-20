using SistemaInventario.Models.Dto;

namespace SistemaInventario.Interfaces.Services
{
    public interface IProveedorService
    {
        Task<IEnumerable<VerProveedorDto>> GetAllProveedorAsync();
        Task<VerProveedorDto> GetProveedorByIdAsync(int id);
        Task<VerProveedorDto> CreateProveedorAsync(CrearProveedorDto crearProveedorDto);
        Task<VerProveedorDto> UpdateProveedorAsync(int id, CrearProveedorDto crearProveedorDto);
        Task <VerProveedorDto> DeleteProveedorAsync(int id);


    }
}
