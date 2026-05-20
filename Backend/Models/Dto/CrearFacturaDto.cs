using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearFacturaDto
    {
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int Clienteid { get; set; }
        [Required(ErrorMessage = "No se puede crear facturas sin productos")]
        public List<CrearDetalleFacturaDto> Detalles { get; set; }
    }
}
