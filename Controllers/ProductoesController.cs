using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SistemaInventario.Models.Dto;
using SistemaInventario.Services;

namespace SistemaInventario.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoesController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerProductoDto>>> GetProducto()
        {
            var productos = await _productoService.GetAllProductoAsync();
            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VerProductoDto>> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound(new { Mensaje = "El producto no existe" });
            }
            return Ok(producto);
        }

        // PUT: api/Productos/5
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, CrearProductoDto ActualizarproductoDto)
        {
            var productoActualizado = await _productoService.UpdateProductoAsync(id, ActualizarproductoDto);
            if (productoActualizado == null)
            {
                return NotFound(new { Mensaje = "El producto no existe" });
            }
            return Ok(new { Mensaje = "Producto actualizado exitosamente", Producto = productoActualizado });
        }

        // POST: api/Productos
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost]
        public async Task<ActionResult> PostProducto(CrearProductoDto CrearProductoDto)
        {
            var nuevoProducto = await _productoService.CreateProductoAsync(CrearProductoDto);
            if (nuevoProducto == null)
            {
                return BadRequest(new { Mensaje = "No se pudo crear el producto" });
            }

            return Ok(new {mensaje="Producto Creado", producto=nuevoProducto});
        }

        // DELETE: api/Productos/5
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound(new { Mensaje = "El producto no existe" });
            }

            await _productoService.DeleteProductoAsync(id);
            return Ok(new { Mensaje = "Producto eliminado" });
        }
    }
}
