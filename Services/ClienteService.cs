using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;


namespace SistemaInventario.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<VerClienteDto>> GetAllClienteAsync()
        {
            var clientes = await _clienteRepository.GetAllClienteAsync();
            
            return clientes.Select(c => new VerClienteDto
            {
                Id = c.Id,
                Nombre = c.Nombre, 
                RNC = c.RNC,
                Telefono = c.Telefono,
                Email = c.Email
            });
        }

        public async Task<VerClienteDto> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null) return null;

            return new VerClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                RNC = cliente.RNC,
                Telefono = cliente.Telefono,
                Email = cliente.Email
            };
        }

        public async Task<VerClienteDto> CreateClienteAsync(CrearClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                RNC = clienteDto.RNC,
                Telefono = clienteDto.Telefono,
                Email = clienteDto.Email
            };

            var result = await _clienteRepository.CreateClienteAsync(cliente);

            if (result)
            {
                return new VerClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    RNC = cliente.RNC,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email
                };
            }

            return null;
        }

        public async Task<VerClienteDto> UpdateClienteAsync(int id, CrearClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null) return null;

            cliente.Nombre = clienteDto.Nombre;
            cliente.RNC = clienteDto.RNC;
            cliente.Telefono = clienteDto.Telefono;
            cliente.Email = clienteDto.Email;

            var result = await _clienteRepository.UpdateClienteAsync(cliente);

            if (result)
            {
                return new VerClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    RNC = cliente.RNC,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email
                };
            }

            return null;
        }

        public async Task<VerClienteDto> DeleteClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null) return null;

            var result = await _clienteRepository.DeleteClienteAsync(id);

            if (result)
            {
                return new VerClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    RNC = cliente.RNC,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email
                };
            }

            return null;
        }
    }
}
