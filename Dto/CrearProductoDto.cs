using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Dto
{
    public class CrearProductoDto
    {
        [Required(ErrorMessage = "Debe introducir un nombre")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        [Range(0.1,double.MaxValue, ErrorMessage = "El mensaje debe ser mayor que 0 ")]
        public decimal PrecioCompra { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "El mensaje debe ser mayor que 0 ")]
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public Estado Estado { get; set; }
    }
}
