using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IAlmacenRepository _almacenRepository;

        public CompraService(ICompraRepository compraRepository, IProductoRepository productoRepository, IProveedorRepository proveedorRepository, IAlmacenRepository almacenRepository)
        {
            _compraRepository = compraRepository;
            _productoRepository = productoRepository;
            _proveedorRepository = proveedorRepository;
            _almacenRepository = almacenRepository;
        }

        public async Task<IEnumerable<VerCompraDto>> GetAllComprasAsync()
        {
            var compras = await _compraRepository.GetAllComprasAsync();
            return compras.Select(c => new VerCompraDto
            {
                Id = c.Id,
                Proveedorid = c.Proveedorid,
                ProveedorNombre = c.Proveedor?.Nombre,
                Almacenid = c.Almacenid,
                AlmacenNombre = c.Almacen?.Nombre,
                Fecha = c.Fecha,
                Total = c.Total,
                Detalles = c.Detalles?.Select(d => new VerDetalleCompraDto
                {
                    Id = d.Id,
                    Productoid = d.Productoid,
                    ProductoNombre = d.Producto?.Nombre,
                    Cantidad = d.Cantidad,
                    PrecioCompra = d.PrecioCompra,
                    SubTotal = d.SubTotal
                }).ToList()
            });
        }

        public async Task<VerCompraDto> GetCompraByIdAsync(int id)
        {
            var c = await _compraRepository.GetCompraByIdAsync(id);
            if (c == null) return null;

            return new VerCompraDto
            {
                Id = c.Id,
                Proveedorid = c.Proveedorid,
                ProveedorNombre = c.Proveedor?.Nombre,
                Almacenid = c.Almacenid,
                AlmacenNombre = c.Almacen?.Nombre,
                Fecha = c.Fecha,
                Total = c.Total,
                Detalles = c.Detalles?.Select(d => new VerDetalleCompraDto
                {
                    Id = d.Id,
                    Productoid = d.Productoid,
                    ProductoNombre = d.Producto?.Nombre,
                    Cantidad = d.Cantidad,
                    PrecioCompra = d.PrecioCompra,
                    SubTotal = d.SubTotal
                }).ToList()
            };
        }

        public async Task<VerCompraDto> CreateCompraAsync(CrearCompraDto dto)
        {
            var proveedor = await _proveedorRepository.GetProveedorByIdAsync(dto.Proveedorid);
            if (proveedor == null) throw new ArgumentException("El proveedor especificado no existe.");

            var almacen = await _almacenRepository.GetAlmacenByIdAsync(dto.Almacenid);
            if (almacen == null) throw new ArgumentException("El almacén especificado no existe.");

            var compra = new Compra
            {
                Proveedorid = dto.Proveedorid,
                Almacenid = dto.Almacenid,
                Fecha = DateTime.Now,
                Detalles = new List<DetalleCompra>()
            };

            decimal totalCalculado = 0;

            foreach (var det in dto.Detalles)
            {
                var producto = await _productoRepository.GetProductoByIdAsync(det.Productoid);
                if (producto != null)
                {
                    var detalleCompra = new DetalleCompra
                    {
                        Productoid = det.Productoid,
                        Cantidad = det.Cantidad,
                        PrecioCompra = det.PrecioCompra
                        // SubTotal se calcula solo
                    };
                    compra.Detalles.Add(detalleCompra);
                    totalCalculado += (detalleCompra.Cantidad * detalleCompra.PrecioCompra);

                    // Opcional: Actualizar el stock del producto automáticamente sumando la cantidad comprada
                    producto.Stock += det.Cantidad;
                    await _productoRepository.UpdateProductoAsync(producto);
                }
            }

            compra.Total = totalCalculado;

            var result = await _compraRepository.CreateCompraAsync(compra);
            if (result)
            {
                return await GetCompraByIdAsync(compra.Id);
            }

            return null;
        }

        public async Task<bool> DeleteCompraAsync(int id)
        {
            // Opcionalmente, podrías revertir el stock aquí antes de borrar, pero para simplificar solo borramos.
            return await _compraRepository.DeleteCompraAsync(id);
        }
    }
}
