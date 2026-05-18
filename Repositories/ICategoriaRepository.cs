using SistemaInventario.Models.Entities;

namespace SistemaInventario.Repositories
{
    public interface ICategoriaRepository
    {
       Task <IEnumerable<Categoria>> GetAllCategoriaAsync();
       Task<Categoria> GetCategoriaByIdAsync(int id);
        Task<bool> CreateCategoriaAsync(Categoria categoria);
        Task<bool> UpdateCategoriaAsync(Categoria categoria);
        Task<bool> DeleteCategoriaAsync(int id);


    }
}
