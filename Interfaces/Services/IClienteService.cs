using SistemaInventario.Models.Dto;

namespace SistemaInventario.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<VerClienteDto>> GetAllClienteAsync();
        Task<VerClienteDto> GetClienteByIdAsync(int id);
        Task<VerClienteDto> CreateClienteAsync(CrearClienteDto ClienteDto);
        Task<VerClienteDto> UpdateClienteAsync(int id, CrearClienteDto ClienteDto);
        Task<VerClienteDto> DeleteClienteAsync(int id);

    }
}
