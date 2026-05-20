using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearDetalleFacturaDto
    {
        [Required(ErrorMessage = "Es necesario poner un id de producto")]
        public int Productoid { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mínimo 1")]
        public int Cantidad { get; set; }
    }
}
