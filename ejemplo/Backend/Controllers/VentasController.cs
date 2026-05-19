using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentasController : ControllerBase
    {
        private readonly CRUDContext _context;

        public VentasController(CRUDContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaResponseDto>>> GetVentas()
        {
            var ventas = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .Select(v => new VentaResponseDto
                {
                    Id = v.Id,
                    Fecha = v.Fecha,
                    Clienteid = v.Clienteid,
                    NombreCliente = v.Cliente != null ? v.Cliente.Nombre : "Desconocido",
                    Productoid = v.Productoid,
                    NombreProducto = v.Producto != null ? v.Producto.NombreProducto : "Desconocido",
                    Total = v.Total
                })
                .ToListAsync();

            return ventas;
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaResponseDto>> GetVentas(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
            {
                return NotFound();
            }

            return new VentaResponseDto
            {
                Id = venta.Id,
                Fecha = venta.Fecha,
                Clienteid = venta.Clienteid,
                NombreCliente = venta.Cliente != null ? venta.Cliente.Nombre : "Desconocido",
                Productoid = venta.Productoid,
                NombreProducto = venta.Producto != null ? venta.Producto.NombreProducto : "Desconocido",
                Total = venta.Total
            };
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentas(int id, Ventas ventas)
        {
            if (id != ventas.Id)
            {
                return BadRequest();
            }

            _context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<VentaResponseDto>> PostVentas(VentaCreateDto dto)
        {
            // 1. Verificar que el cliente existe
            var clienteEnBaseDatos = await _context.Cliente.FindAsync(dto.Clienteid);
            if (clienteEnBaseDatos == null)
            {
                return BadRequest("El cliente no existe.");
            }

            // 2. Verificar que el producto existe
            var productoEnBaseDatos = await _context.Producto.FindAsync(dto.Productoid);
            if (productoEnBaseDatos == null)
            {
                return BadRequest("El producto no existe.");
            }

            // --- NUEVA LÓGICA DE STOCK ---
            // 3. Verificar si hay stock disponible (asumiendo que vendes 1 por transacción)
            // Si tu DTO tiene una propiedad 'Cantidad', usa dto.Cantidad en lugar de 1
            if (productoEnBaseDatos.Stock <= 0)
            {
                return BadRequest("No hay stock disponible para este producto.");
            }

            // 4. RESTAR EL STOCK
            // Aquí es donde el 500 baja a 499 en la base de datos
            productoEnBaseDatos.Stock -= 1;
            // ------------------------------

            // 5. Construir la entidad Ventas
            var ventas = new Ventas
            {
                Fecha = DateTime.Now,
                Clienteid = dto.Clienteid,
                Productoid = dto.Productoid,
                Total = productoEnBaseDatos.Precio
            };

            // 6. Guardar la venta y la actualización del producto
            _context.Ventas.Add(ventas);

            // Al hacer SaveChanges, Entity Framework detecta que productoEnBaseDatos.Stock cambió
            // y enviará un UPDATE a la tabla Productos automáticamente.
            await _context.SaveChangesAsync();

            // 7. Devolver respuesta
            var respuesta = new VentaResponseDto
            {
                Id = ventas.Id,
                Fecha = ventas.Fecha,
                Clienteid = ventas.Clienteid,
                NombreCliente = clienteEnBaseDatos.Nombre,
                Productoid = ventas.Productoid,
                NombreProducto = productoEnBaseDatos.NombreProducto,
                Total = ventas.Total
            };

            return CreatedAtAction("GetVentas", new { id = ventas.Id }, respuesta);
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
