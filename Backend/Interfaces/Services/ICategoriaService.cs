using SistemaInventario.Models.Dto;

namespace SistemaInventario.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<VerCategoriaDto>> GetAllCategoriaAsync();
        Task<VerCategoriaDto> GetCategoriaByIdAsync(int id);
        Task<VerCategoriaDto> CreateCategoriaAsync(CrearCategoriaDto crearCategoriaDto);
        Task<VerCategoriaDto> UpdateCategoriaAsync(int id, CrearCategoriaDto crearCategoriaDto);
        Task<VerCategoriaDto> DeleteCategoriaAsync(int id);
    }
}
