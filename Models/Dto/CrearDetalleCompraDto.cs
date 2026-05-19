using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearDetalleCompraDto
    {
        [Required(ErrorMessage = "El producto es obligatorio")]
        public int Productoid { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0")]
        public int Cantidad { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio de compra debe ser mayor que 0")]
        public decimal PrecioCompra { get; set; }
    }
}
