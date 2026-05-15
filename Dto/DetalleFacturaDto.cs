using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Dto
{
    public class DetalleFacturaDto
    {
        [Required(ErrorMessage =("Es necesario poner un id"))]
        public int Productoid { get; set;}
        [Required]
        [Range(1, int.MaxValue, ErrorMessage =("tiene que tener valor minimo 1"))]
        public int Cantidad { get; set; } 
    }
}
