using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class LoginUsuarioDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contraseña { get; set; }
    }
}
