using SistemaInventario.Enums;

namespace SistemaInventario.Models.Dto
{
    public class VerUsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Rol Rol { get; set; }
    }
}
