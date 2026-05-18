using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class LoginUsuarioDto
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contraseña { get; set; }
    }
}
