using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearUsuarioDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contraseña { get; set; }
        [Required]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmarContraseña { get; set; }
        public Rol Rol { get; set; }
    }
}
