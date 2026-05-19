using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

    }
}
