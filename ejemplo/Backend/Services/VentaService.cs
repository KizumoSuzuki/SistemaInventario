using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository    _ventaRepo;
        private readonly IClienteRepository  _clienteRepo;
        private readonly IProductoRepository _productoRepo;

        public VentaService(
            IVentaRepository    ventaRepo,
            IClienteRepository  clienteRepo,
            IProductoRepository productoRepo)
        {
            _ventaRepo    = ventaRepo;
            _clienteRepo  = clienteRepo;
            _productoRepo = productoRepo;
        }

        public Task<IEnumerable<Ventas>> GetAllAsync()
            => _ventaRepo.GetAllAsync();

        public Task<Ventas?> GetByIdAsync(int id)
            => _ventaRepo.GetByIdAsync(id);

        public async Task<VentaResponseDto> CreateAsync(VentaCreateDto dto)
        {
            // 1. Verificar que el cliente existe
            var cliente = await _clienteRepo.GetByIdAsync(dto.Clienteid)
                ?? throw new KeyNotFoundException("El cliente no existe.");

            // 2. Verificar que el producto existe
            var producto = await _productoRepo.GetByIdAsync(dto.Productoid)
                ?? throw new KeyNotFoundException("El producto no existe.");

            // 3. Crear la venta
            var venta = new Ventas
            {
                Fecha      = DateTime.Now,
                Clienteid  = dto.Clienteid,
                Productoid = dto.Productoid,
                Total      = producto.Precio
            };

            await _ventaRepo.CreateAsync(venta);

            // 4. Devolver DTO con nombres
            return new VentaResponseDto
            {
                Id             = venta.Id,
                Fecha          = venta.Fecha,
                Clienteid      = venta.Clienteid,
                NombreCliente  = cliente.Nombre,
                Productoid     = venta.Productoid,
                NombreProducto = producto.NombreProducto,
                Total          = venta.Total
            };
        }

        public Task<bool> UpdateAsync(int id, Ventas venta)
            => _ventaRepo.UpdateAsync(id, venta);

        public Task<bool> DeleteAsync(int id)
            => _ventaRepo.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _ventaRepo.ExistsAsync(id);
    }
}
