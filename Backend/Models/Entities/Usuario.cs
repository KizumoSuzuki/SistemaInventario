using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public Rol Rol { get; set; }

    }
}
