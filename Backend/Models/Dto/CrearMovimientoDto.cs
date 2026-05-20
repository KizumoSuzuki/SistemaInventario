using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearMovimientoDto
    {
        [Required(ErrorMessage = "El producto es obligatorio")]
        public int Productoid { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mínimo 1")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El tipo de movimiento es obligatorio")]
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
