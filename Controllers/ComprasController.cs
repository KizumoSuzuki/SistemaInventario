using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaInventario.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public ComprasController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerCompraDto>>> GetCompras()
        {
            var compras = await _compraService.GetAllComprasAsync();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerCompraDto>> GetCompra(int id)
        {
            var compra = await _compraService.GetCompraByIdAsync(id);
            if (compra == null) return NotFound(new { mensaje = "La compra no existe" });

            return Ok(compra);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost]
        public async Task<ActionResult<VerCompraDto>> PostCompra(CrearCompraDto dto)
        {
            try
            {
                var nuevaCompra = await _compraService.CreateCompraAsync(dto);
                if (nuevaCompra == null) return BadRequest(new { mensaje = "Error al registrar la compra" });

                return CreatedAtAction(nameof(GetCompra), new { id = nuevaCompra.Id }, nuevaCompra);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var eliminada = await _compraService.DeleteCompraAsync(id);
            if (!eliminada) return NotFound(new { mensaje = "La compra no existe" });

            return NoContent();
        }
    }
}
