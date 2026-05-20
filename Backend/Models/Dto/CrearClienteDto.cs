using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearClienteDto
    {
        [Required(ErrorMessage = "Introduzca un nombre valido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Introduzco un RNC valido")]
        public string RNC { get; set; }
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage = "Introduzca un correo valido")]
        public string Email { get; set; }
    }
}
