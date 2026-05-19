using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearCompraDto
    {
        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public int Proveedorid { get; set; }
        
        [Required(ErrorMessage = "El almacén es obligatorio")]
        public int Almacenid { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle en la compra")]
        public List<CrearDetalleCompraDto> Detalles { get; set; }
    }
}
