using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SistemaInventario.Models.Dto;
using SistemaInventario.Services;

namespace SistemaInventario.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        // GET: api/Factura
        [HttpGet]
    public async Task<ActionResult<IEnumerable<VerFacturaDto>>> GetFactura()
    {
        var facturas = await _facturaService.GetAllFacturaAsync();
        return Ok(facturas);
    }

    // GET: api/Factura/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VerFacturaDto>> GetFactura(int id)
    {
       var factura = await _facturaService.GetFacturaByIdAsync(id);
        if (factura == null)
        {
            return NotFound(new { Mensaje = "La factura no existe" });
        }
        return Ok(factura);
    }

    // PUT: api/Factura/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPut("{id}")]
    public async Task<IActionResult> PutFactura(int id, CrearFacturaDto ActualizarFacturaDto)
    {
        var facturaActualizada = await _facturaService.UpdateFacturaAsync(id, ActualizarFacturaDto);
        if (facturaActualizada == null)
        {
            return NotFound(new { Mensaje = "La factura no existe" });
        }
        return Ok(new {mensaje="Factura actualizada", factura= facturaActualizada});

    }

    // POST: api/Factura
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost]
    public async Task<ActionResult<CrearFacturaDto>> PostFactura(CrearFacturaDto CrearfacturaDto)
    {
        var nuevaFactura = await _facturaService.CreateFacturaAsync(CrearfacturaDto);
        if (nuevaFactura == null)
        {
            return BadRequest(new { Mensaje = "No se pudo crear la factura" });
        }
        return Ok(new {mensaje= "Factura Creada", factura=nuevaFactura});
    }

    // DELETE: api/Factura/5
    [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFactura(int id)
    {
       var factura = await _facturaService.GetFacturaByIdAsync(id);
        if (factura == null)
        {
            return NotFound(new { Mensaje = "La factura no existe" });
        }
        await _facturaService.DeleteFacturaAsync(id);
        return Ok(new {mensaje="Factura eliminada"});
    }

 
}
}
