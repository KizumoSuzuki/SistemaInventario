using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;


namespace SistemaInventario.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IProductoRepository _productoRepository;

        public FacturaService(IFacturaRepository facturaRepository, IProductoRepository productoRepository)
        {
            _facturaRepository = facturaRepository;
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<VerFacturaDto>> GetAllFacturaAsync()
        {
            var facturas = await _facturaRepository.GetAllFacturaAsync();

            return facturas.Select(c => new VerFacturaDto
            {
                Id = c.Id,
                Clienteid = c.Clienteid,
                ClienteNombre = c.Cliente?.Nombre, 
                Total = c.Total,
                Fechainicio = c.Fechainicio,
                Fechalimite = c.Fechalimite,
                Detalles = c.Detalles?.Select(d => new VerDetalleFacturaDto
                {
                    Id = d.Id,
                    Productoid = d.Productoid,
                    ProductoNombre = d.Producto?.Nombre, 
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList() ?? new List<VerDetalleFacturaDto>()
            });
        }

        public async Task<VerFacturaDto> GetFacturaByIdAsync(int id)
        {
            var factura = await _facturaRepository.GetFacturaByIdAsync(id);
            if (factura == null) return null;

            return new VerFacturaDto
            {
                Id = factura.Id,
                Clienteid = factura.Clienteid,
                ClienteNombre = factura.Cliente?.Nombre,
                Total = factura.Total,
                Fechainicio = factura.Fechainicio,
                Fechalimite = factura.Fechalimite,
                Detalles = factura.Detalles?.Select(d => new VerDetalleFacturaDto
                {
                    Id = d.Id,
                    Productoid = d.Productoid,
                    ProductoNombre = d.Producto?.Nombre,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList() ?? new List<VerDetalleFacturaDto>()
            };
        }

        public async Task<VerFacturaDto> CreateFacturaAsync(CrearFacturaDto facturaDto)
        {
            var factura = new Factura
            {
                Clienteid = facturaDto.Clienteid,
                Fechainicio = DateOnly.FromDateTime(DateTime.Now),
                Fechalimite = DateOnly.FromDateTime(DateTime.Now.AddDays(30)),
                Detalles = new List<DetalleFactura>()
            };

            decimal totalCalculado = 0;

            foreach (var detalleDto in facturaDto.Detalles)
            {
                var producto = await _productoRepository.GetProductoByIdAsync(detalleDto.Productoid);
                if (producto != null)
                {
                    var detalle = new DetalleFactura
                    {
                        Productoid = detalleDto.Productoid,
                        Cantidad = detalleDto.Cantidad,
                        PrecioUnitario = producto.Venta
                    };
                    totalCalculado += detalle.Cantidad * detalle.PrecioUnitario;
                    factura.Detalles.Add(detalle);
                }
            }

            factura.Total = totalCalculado;

            var result = await _facturaRepository.CreateFacturaAsync(factura);

            if (result)
            {
                return await GetFacturaByIdAsync(factura.Id);
            }

            return null;
        }

        public async Task<VerFacturaDto> UpdateFacturaAsync(int id, CrearFacturaDto facturaDto)
        {
            var factura = await _facturaRepository.GetFacturaByIdAsync(id);
            if (factura == null) return null;

            factura.Clienteid = facturaDto.Clienteid;

            factura.Detalles.Clear();
            decimal totalCalculado = 0;

            foreach (var detalleDto in facturaDto.Detalles)
            {
                var producto = await _productoRepository.GetProductoByIdAsync(detalleDto.Productoid);
                if (producto != null)
                {
                    factura.Detalles.Add(new DetalleFactura
                    {
                        Productoid = detalleDto.Productoid,
                        Cantidad = detalleDto.Cantidad,
                        PrecioUnitario = producto.Venta
                    });
                    totalCalculado += detalleDto.Cantidad * producto.Venta;
                }
            }

            factura.Total = totalCalculado;

            var result = await _facturaRepository.UpdateFacturaAsync(id, factura);

            if (result)
            {
                return await GetFacturaByIdAsync(factura.Id);
            }

            return null;
        }

        public async Task<VerFacturaDto> DeleteFacturaAsync(int id)
        {
            var factura = await _facturaRepository.GetFacturaByIdAsync(id);
            if (factura == null) return null;

            var facturaEliminada = await GetFacturaByIdAsync(id);

            var result = await _facturaRepository.DeleteFacturaAsync(id);

            if (result)
            {
                return facturaEliminada;
            }

            return null;
        }
    }
}