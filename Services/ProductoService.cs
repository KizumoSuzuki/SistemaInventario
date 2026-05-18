using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;
using SistemaInventario.Repositories;


namespace SistemaInventario.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<VerProductoDto>> GetAllProductoAsync()
        {
            var productos = await _productoRepository.GetAllProductosAsync();

            return productos.Select(p => new VerProductoDto
            {
                Id = p.Id,
                CodigoProducto = p.CodigoProducto,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                PrecioCompra = p.Compra,
                PrecioVenta = p.Venta,
                Stock = p.Stock,
                UnidadMedida = p.UnidadMedida,
                Categoriaid = p.Categoriaid,
                CategoriaNombre = p.Categoria?.Nombre,
                Proveedorid = p.Proveedorid,
                ProveedorNombre = p.Proveedor?.Nombre
            });
        }

        public async Task<VerProductoDto> GetProductoByIdAsync(int id)
        {
            var p = await _productoRepository.GetProductoByIdAsync(id);
            if (p == null) return null;

            return new VerProductoDto
            {
                Id = p.Id,
                CodigoProducto = p.CodigoProducto,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                PrecioCompra = p.Compra,
                PrecioVenta = p.Venta,
                Stock = p.Stock,
                UnidadMedida = p.UnidadMedida,
                Categoriaid = p.Categoriaid,
                CategoriaNombre = p.Categoria?.Nombre,
                Proveedorid = p.Proveedorid,
                ProveedorNombre = p.Proveedor?.Nombre
            };
        }

        public async Task<VerProductoDto> CreateProductoAsync(CrearProductoDto dto)
        {
            var producto = new Producto
            {
                CodigoProducto = $"PROD-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}",
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Compra = dto.PrecioCompra,
                Venta = dto.PrecioVenta,
                Stock = dto.Stock,
                UnidadMedida = dto.UnidadMedida,
                Categoriaid = dto.Categoriaid,
                Proveedorid = dto.Proveedorid
            };

            var result = await _productoRepository.CreateProductoAsync(producto);

            if (result)
            {
                return await GetProductoByIdAsync(producto.Id);
            }

            return null;
        }

        public async Task<VerProductoDto> UpdateProductoAsync(int id, CrearProductoDto dto)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(id);
            if (producto == null) return null;

            producto.Nombre = dto.Nombre;
            producto.Descripcion = dto.Descripcion;
            producto.Compra = dto.PrecioCompra;
            producto.Venta = dto.PrecioVenta;
            producto.Stock = dto.Stock;
            producto.UnidadMedida = dto.UnidadMedida;
            producto.Categoriaid = dto.Categoriaid;
            producto.Proveedorid = dto.Proveedorid;

            var result = await _productoRepository.UpdateProductoAsync(producto);

            if (result)
            {
                return await GetProductoByIdAsync(producto.Id);
            }

            return null;
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            return await _productoRepository.DeleteProductoAsync(id);
        }

        public async Task<bool> ActualizarStockAsync(int productoid, int cantidad)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(productoid);
            if (producto == null) return false;

            producto.Stock += cantidad;

            return await _productoRepository.UpdateProductoAsync(producto);
        }
    }
}
