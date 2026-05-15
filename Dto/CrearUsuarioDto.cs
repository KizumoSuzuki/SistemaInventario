using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Dto
{
    public class CrearUsuarioDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public string Contraseña { get; set; }
        [Required]
        [Compare("Contraseña", ErrorMessage =("Las contraseñas no son iguales"))]
        public string ConfirmarContraseña { get; set; }
        public Rol Rol { get; set; } 
    }
}
