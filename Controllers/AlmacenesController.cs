using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Models.Dto;
using SistemaInventario.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly IAlmacenService _almacenService;

        public AlmacenesController(IAlmacenService almacenService)
        {
            _almacenService = almacenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerAlmacenDto>>> GetAlmacenes()
        {
            var almacenes = await _almacenService.GetAllAlmacenesAsync();
            return Ok(almacenes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerAlmacenDto>> GetAlmacen(int id)
        {
            var almacen = await _almacenService.GetAlmacenByIdAsync(id);
            if (almacen == null) return NotFound(new { mensaje = "El almacén no existe" });
            
            return Ok(almacen);
        }

        [HttpPost]
        public async Task<ActionResult<VerAlmacenDto>> PostAlmacen(CrearAlmacenDto CrearAlmacenDto)
        {
            var nuevoAlmacen = await _almacenService.CreateAlmacenAsync(CrearAlmacenDto);
            if (nuevoAlmacen == null) return BadRequest(new { mensaje = "Error al crear almacén" });

            return Ok(new {mensaje="Almacen creado", Almacen=nuevoAlmacen});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(int id, CrearAlmacenDto ActualizarAlmacenDto)
        {
            var actualizado = await _almacenService.UpdateAlmacenAsync(id, ActualizarAlmacenDto);
            if (actualizado == null) return NotFound(new { mensaje = "El almacén no existe o no se pudo actualizar" });

            return Ok(new {mensaje=""});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacen(int id)
        {
            var eliminado = await _almacenService.DeleteAlmacenAsync(id);
            if (!eliminado) return NotFound(new { mensaje = "El almacén no existe" });

            return NoContent();
        }
    }
}
