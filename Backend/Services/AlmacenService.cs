using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class AlmacenService : IAlmacenService
    {
        private readonly IAlmacenRepository _almacenRepository;

        public AlmacenService(IAlmacenRepository almacenRepository)
        {
            _almacenRepository = almacenRepository;
        }

        public async Task<IEnumerable<VerAlmacenDto>> GetAllAlmacenesAsync()
        {
            var almacenes = await _almacenRepository.GetAllAlmacenesAsync();
            return almacenes.Select(a => new VerAlmacenDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Ubicacion = a.Ubicacion,
                Capacidad = a.Capacidad,
                Productos = a.AlmacenProductos?.Select(ap => new ProductoEnAlmacenDto
                {
                    ProductoId = ap.ProductoId,
                    NombreProducto = ap.Producto?.Nombre ?? "Desconocido",
                    CodigoProducto = ap.Producto?.CodigoProducto ?? "N/A",
                    Stock = ap.Stock
                }).ToList() ?? new List<ProductoEnAlmacenDto>()
            });
        }

        public async Task<VerAlmacenDto> GetAlmacenByIdAsync(int id)
        {
            var a = await _almacenRepository.GetAlmacenByIdAsync(id);
            if (a == null) return null;

            return new VerAlmacenDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Ubicacion = a.Ubicacion,
                Capacidad = a.Capacidad,
                Productos = a.AlmacenProductos?.Select(ap => new ProductoEnAlmacenDto
                {
                    ProductoId = ap.ProductoId,
                    NombreProducto = ap.Producto?.Nombre ?? "Desconocido",
                    CodigoProducto = ap.Producto?.CodigoProducto ?? "N/A",
                    Stock = ap.Stock
                }).ToList() ?? new List<ProductoEnAlmacenDto>()
            };
        }

        public async Task<VerAlmacenDto> CreateAlmacenAsync(CrearAlmacenDto dto)
        {
            var almacen = new Almacen
            {
                Nombre = dto.Nombre,
                Ubicacion = dto.Ubicacion,
                Capacidad = dto.Capacidad
            };

            var result = await _almacenRepository.CreateAlmacenAsync(almacen);
            if (result)
            {
                return new VerAlmacenDto
                {
                    Id = almacen.Id,
                    Nombre = almacen.Nombre,
                    Ubicacion = almacen.Ubicacion,
                    Capacidad = almacen.Capacidad
                };
            }
            return null;
        }

        public async Task<VerAlmacenDto> UpdateAlmacenAsync(int id, CrearAlmacenDto dto)
        {
            var almacen = await _almacenRepository.GetAlmacenByIdAsync(id);
            if (almacen == null) return null;

            almacen.Nombre = dto.Nombre;
            almacen.Ubicacion = dto.Ubicacion;
            almacen.Capacidad = dto.Capacidad;

            var result = await _almacenRepository.UpdateAlmacenAsync(almacen);
            if (result)
            {
                return new VerAlmacenDto
                {
                    Id = almacen.Id,
                    Nombre = almacen.Nombre,
                    Ubicacion = almacen.Ubicacion,
                    Capacidad = almacen.Capacidad
                };
            }
            return null;
        }

        public async Task<bool> DeleteAlmacenAsync(int id)
        {
            return await _almacenRepository.DeleteAlmacenAsync(id);
        }

        public async Task<bool> AsignarProductoAsync(AsignarProductoAlmacenDto dto)
        {
            if (dto.Cantidad <= 0) return false;

            return await _almacenRepository.AñadirProductoAlAlmacenAsync(
                dto.AlmacenId,
                dto.ProductoId,
                dto.Cantidad
            );
        }
    }
}