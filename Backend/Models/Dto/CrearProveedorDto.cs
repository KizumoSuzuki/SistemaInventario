using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearProveedorDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El RNC es obligatorio")]
        public string RNC { get; set; }
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; }
        public string Direccion { get; set; }
        public Estado Estado { get; set; }
    }
}
