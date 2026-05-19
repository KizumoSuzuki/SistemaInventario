using SistemaInventario.Enums;
using System.ComponentModel; // <-- Asegúrate de importar esto
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Dto
{
    public class CrearProductoDto
    {
        [Required(ErrorMessage = "Debe introducir un nombre")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        [DefaultValue(0.00)] // <-- Obliga a Swagger a usar 0.00 en el ejemplo
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "El precio de compra debe ser mayor que 0")]
        public decimal PrecioCompra { get; set; }

        [Required]
        [DefaultValue(0.00)] // <-- Lo mismo para el precio de venta
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "El precio de venta debe ser mayor que 0")]
        public decimal PrecioVenta { get; set; }

        public int Stock { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria")]
        public UnidadMedida UnidadMedida { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int Categoriaid { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public int Proveedorid { get; set; }
    }
}