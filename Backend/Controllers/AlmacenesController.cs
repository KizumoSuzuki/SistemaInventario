using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;

namespace SistemaInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlmacenesController : ControllerBase
    {
        private readonly IAlmacenService _almacenService;

        public AlmacenesController(IAlmacenService almacenService)
        {
            _almacenService = almacenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var almacenes = await _almacenService.GetAllAlmacenesAsync();
            return Ok(almacenes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var almacen = await _almacenService.GetAlmacenByIdAsync(id);
            if (almacen == null)
            {
                return NotFound(new { mensaje = $"Almacén con ID {id} no encontrado." });
            }
            return Ok(almacen);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearAlmacenDto CrearAlmacenDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoAlmacen = await _almacenService.CreateAlmacenAsync(CrearAlmacenDto);
            if (nuevoAlmacen == null)
            {
                return BadRequest(new { mensaje = "No se pudo crear el almacén." });
            }

            return CreatedAtAction(nameof(GetById), new { id = nuevoAlmacen.Id }, nuevoAlmacen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearAlmacenDto ActualizarAlmacenDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var almacenActualizado = await _almacenService.UpdateAlmacenAsync(id, ActualizarAlmacenDto);
            if (almacenActualizado == null)
            {
                return NotFound(new { mensaje = $"No se encontró el almacén con ID {id} para actualizar." });
            }

            return Ok(almacenActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _almacenService.DeleteAlmacenAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = $"No se pudo eliminar. Almacén con ID {id} no encontrado." });
            }

            return Ok(new { mensaje = "Almacén eliminado correctamente." });
        }

        [HttpPost("asignar-producto")]
        public async Task<IActionResult> AsignarProducto([FromBody] AsignarProductoAlmacenDto AsignarProductoAlmacenDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = await _almacenService.AsignarProductoAsync(AsignarProductoAlmacenDto);
            if (!resultado)
            {
                return BadRequest(new { mensaje = "No se pudo asignar el producto. Verifica los IDs y que la cantidad sea mayor a 0." });
            }

            return Ok(new { mensaje = "Producto y stock asignados al almacén correctamente." });
        }
    }
}