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
public class ProveedorsController : ControllerBase
{
    private readonly IProveedorService _proveedorService;
    public ProveedorsController(IProveedorService proveedorService)
    {
        _proveedorService = proveedorService;
    }

    // GET: api/Proveedor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VerProveedorDto>>> GetProveedor()
    {
         var proveedores = await _proveedorService.GetAllProveedorAsync();
        return Ok(proveedores);
    }

    // GET: api/Proveedor/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VerProveedorDto>> GetProveedor(int id)
    {
        var proveedor = await _proveedorService.GetProveedorByIdAsync(id);
        if (proveedor == null)
        {
            return NotFound(new { mensaje = "El proveedor no existe"});
        }
        return Ok(proveedor);
    }

    // PUT: api/Proveedor/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProveedor(int id, CrearProveedorDto ActualizarProveedorDto)
    {
       var proveedorActualizado = await _proveedorService.UpdateProveedorAsync(id, ActualizarProveedorDto);
        if (proveedorActualizado == null)
        {
            return NotFound(new { mensaje = "El proveedor no existe" });
        }
        return Ok(new { mensaje = "Proveedor actualizado exitosamente", Proveedor = proveedorActualizado });
    }

    // POST: api/Proveedor
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CrearProveedorDto>> PostProveedor(CrearProveedorDto CrearProveedorDto)
    {
       var nuevoProveedor = await _proveedorService.CreateProveedorAsync(CrearProveedorDto);
        return Ok(new {mensaje="Proveedor creado", proveedor= nuevoProveedor});
    }

    // DELETE: api/Proveedor/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProveedor(int id)
    {
        var proveedorEliminado = await _proveedorService.DeleteProveedorAsync(id);
        if (proveedorEliminado == null)
        {
            return NotFound(new { mensaje = "El proveedor no existe" });
        }
        return Ok(new { mensaje = "Proveedor eliminado exitosamente", Proveedor = proveedorEliminado });
    }
    }
}
