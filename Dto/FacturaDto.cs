using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Dto
{
    public class FacturaDto
    {
        [Required]

        public int Usuarioid { get; set; }
        [Required(ErrorMessage =("No se puede crear facturas sin productos"))]
        public List<DetalleFacturaDto> Detalles { get; set; }

    }
}
