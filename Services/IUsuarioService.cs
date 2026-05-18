using SistemaInventario.Models.Dto;

namespace SistemaInventario.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<VerUsuarioDto>> GetAllUsuarioAsync();
        Task<VerUsuarioDto> GetUsuarioByIdAsync(int id);
        Task<VerUsuarioDto> CreateUsuarioAsync(CrearUsuarioDto crearUsuarioDto);
        Task<VerUsuarioDto> UpdateUsuarioAsync(int id, CrearUsuarioDto crearUsuarioDto);
        Task<VerUsuarioDto> DeleteUsuarioAsync(int id);
        Task<VerUsuarioDto> LoginAsync(LoginUsuarioDto loginUsuarioDto);
    }
}
