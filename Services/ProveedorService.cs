using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;
using SistemaInventario.Repositories;


namespace SistemaInventario.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<IEnumerable<VerProveedorDto>> GetAllProveedorAsync()
        {
            var proveedores = await _proveedorRepository.GetAllProveedorAsync();
            return proveedores.Select(p => new VerProveedorDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                RNC = p.RNC,
                Telefono = p.Telefono,
                Email = p.Email,
                Direccion = p.Direccion,
                Estado = p.Estado
            });
        }

        public async Task<VerProveedorDto> GetProveedorByIdAsync(int id)
        {
            var p = await _proveedorRepository.GetProveedorByIdAsync(id);
            if (p == null) return null;

            return new VerProveedorDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                RNC = p.RNC,
                Telefono = p.Telefono,
                Email = p.Email,
                Direccion = p.Direccion,
                Estado = p.Estado
            };
        }

        public async Task<VerProveedorDto> CreateProveedorAsync(CrearProveedorDto dto)
        {
            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                RNC = dto.RNC,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Direccion = dto.Direccion,
                Estado = dto.Estado
            };

            var result = await _proveedorRepository.CreateProveedorAsync(proveedor);

            if (result)
            {
                return new VerProveedorDto
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre,
                    RNC = proveedor.RNC,
                    Telefono = proveedor.Telefono,
                    Email = proveedor.Email,
                    Direccion = proveedor.Direccion,
                    Estado = proveedor.Estado
                };
            }

            return null;
        }

        public async Task<VerProveedorDto> UpdateProveedorAsync(int id, CrearProveedorDto dto)
        {
            var proveedor = await _proveedorRepository.GetProveedorByIdAsync(id);
            if (proveedor == null) return null;

            proveedor.Nombre = dto.Nombre;
            proveedor.RNC = dto.RNC;
            proveedor.Telefono = dto.Telefono;
            proveedor.Email = dto.Email;
            proveedor.Direccion = dto.Direccion;
            proveedor.Estado = dto.Estado;

            var result = await _proveedorRepository.UpdateProveedorAsync(proveedor);

            if (result)
            {
                return new VerProveedorDto
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre,
                    RNC = proveedor.RNC,
                    Telefono = proveedor.Telefono,
                    Email = proveedor.Email,
                    Direccion = proveedor.Direccion,
                    Estado = proveedor.Estado
                };
            }

            return null;
        }

        public async Task<VerProveedorDto> DeleteProveedorAsync(int id)
        {
            var proveedor = await _proveedorRepository.GetProveedorByIdAsync(id);
            if (proveedor == null) return null;

            var result = await _proveedorRepository.DeleteProveedorAsync(id);

            if (result)
            {
                return new VerProveedorDto
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre,
                    RNC = proveedor.RNC,
                    Telefono = proveedor.Telefono,
                    Email = proveedor.Email,
                    Direccion = proveedor.Direccion,
                    Estado = proveedor.Estado
                };
            }

            return null;
        }
    }
}
