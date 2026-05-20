using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;


namespace SistemaInventario.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerCategoriaDto>>> GetCategorias()
        {
            var categorias = await _categoriaService.GetAllCategoriaAsync();
            return Ok(categorias);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VerCategoriaDto>> GetCategoria(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);

            if (categoria == null)
            {
                return NotFound(new { mensaje = "La categoría no existe." });
            }

            return Ok(categoria);
        }

        // POST: api/Categorias
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost]
        public async Task<ActionResult<VerCategoriaDto>> PostCategoria(CrearCategoriaDto crearCategoriaDto)
        {
            var nuevaCategoria = await _categoriaService.CreateCategoriaAsync(crearCategoriaDto);
            
            if (nuevaCategoria == null)
            {
                return BadRequest(new { mensaje = "No se pudo crear la categoría." });
            }

            return Ok(new {mensaje = "Categoria creada", Categoria = nuevaCategoria });
        }
        // PUT: api/Categorias/5
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CrearCategoriaDto actualizarCategoriaDto)
        {
            var categoriaActualizada = await _categoriaService.UpdateCategoriaAsync(id, actualizarCategoriaDto);

            if (categoriaActualizada == null)
            {
                return NotFound(new { mensaje = "La categoría no existe o no se pudo actualizar" });
            }

            return Ok(new {Mensaje="Categoria Actualizada", Categoria = categoriaActualizada});
        }

        // DELETE: api/Categorias/5
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoriaEliminada = await _categoriaService.DeleteCategoriaAsync(id);

            if (categoriaEliminada == null)
            {
                return NotFound(new { mensaje = "La categoría no existe" });
            }

            // Devolvemos los datos que acabamos de borrar por si el frontend los necesita
            return Ok(new { mensaje = "La categoría fue eliminado" }); 
        }
    }
}
