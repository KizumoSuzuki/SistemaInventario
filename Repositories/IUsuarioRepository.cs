using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuarioAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<bool> CreateUsuarioAsync(Usuario usuario);
        Task<bool> UpdateUsuarioAsync(Usuario usuario);
        Task <bool> DeleteUsuarioAsync(int id);
    }
}
