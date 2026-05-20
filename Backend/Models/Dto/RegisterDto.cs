using System.ComponentModel.DataAnnotations;
using SistemaInventario.Enums;

namespace SistemaInventario.Models.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El usuario (email) es obligatorio")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contraseña { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        /// <summary>
        /// Rol permitido: 0 = Usuario (solo lectura), 1 = Admin (puede crear/editar/borrar datos)
        /// </summary>
        [Required]
        public Rol Rol { get; set; }
    }
}
