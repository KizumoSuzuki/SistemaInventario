using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Models.Dto;
using SistemaInventario.Services;

namespace SistemaInventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuarios
        // Todos los autenticados pueden ver la lista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerUsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuarioAsync();
            return Ok(usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VerUsuarioDto>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new { Mensaje = "El usuario no existe" });
            }
            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        // Solo SuperAdmin y Admin pueden editar
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, CrearUsuarioDto actualizarUsuarioDto)
        {
            var usuarioActualizado = await _usuarioService.UpdateUsuarioAsync(id, actualizarUsuarioDto);
            if (usuarioActualizado == null)
            {
                return NotFound(new { Mensaje = "El usuario no existe o no se pudo actualizar" });
            }
            return Ok(new { Mensaje = "Usuario actualizado exitosamente", Usuario = usuarioActualizado });
        }

        // DELETE: api/Usuarios/5
        // Solo SuperAdmin y Admin pueden borrar
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            // Opcional: Proteger para que no se pueda borrar al SuperAdmin (id=1)
            if (id == 1)
                return Forbid("No se puede eliminar la cuenta principal de Super Administrador.");

            var eliminado = await _usuarioService.DeleteUsuarioAsync(id);
            if (eliminado == null)
            {
                return NotFound(new { Mensaje = "El usuario no existe" });
            }
            return NoContent();
        }
    }
}
