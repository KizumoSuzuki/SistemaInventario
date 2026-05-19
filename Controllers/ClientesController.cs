using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SistemaInventario.Models.Dto;
using SistemaInventario.Services;

namespace SistemaInventario.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/Cliente
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VerClienteDto>>> GetCliente()
    {
        var clientes = await _clienteService.GetAllClienteAsync();
        return Ok(clientes);
    }

    // GET: api/Cliente/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VerClienteDto>> GetCliente(int id)
    {
        var cliente = await _clienteService.GetClienteByIdAsync(id);

        if (cliente == null)
        {
            return NotFound(new {Mensaje = "El cliente no existe" } );
        }

        return Ok(cliente);
    }

    // PUT: api/Cliente/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, CrearClienteDto ActualizarClienteDto)
    {
       var ClienteActualizado = await _clienteService.UpdateClienteAsync(id, ActualizarClienteDto);
        if (ClienteActualizado == null)
        {
            return NotFound(new { Mensaje = "El cliente no existe o no se pudo actualizar" });
        }
        return Ok(new {Mensaje="Cliente Actualizado", Cliente = ClienteActualizado} );
    }

    // POST: api/Cliente
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CrearClienteDto>> PostCliente(CrearClienteDto CrearClienteDto)
    {
    var nuevoCliente = await _clienteService.CreateClienteAsync(CrearClienteDto);
    if (nuevoCliente == null)
        {
            return BadRequest(new { Mensaje = "No se pudo crear el cliente" });
        }
        return Ok(new { Mensaje = "Cliente creado exitosamente", Cliente = nuevoCliente });
    }
    // DELETE: api/Cliente/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
       var clienteEliminado = await _clienteService.DeleteClienteAsync(id);
        if (clienteEliminado == null)
        {
            return NotFound(new { Mensaje = "El cliente no existe" });
        }
        return Ok(new {mensaje="Cliente Eliminado"});
     }
    }
}
