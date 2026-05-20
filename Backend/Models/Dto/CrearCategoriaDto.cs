using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearCategoriaDto
    {
        [Required(ErrorMessage = "Introduzca el nombre de la categoria")]
        public string Nombre { get; set; }
    }
}
