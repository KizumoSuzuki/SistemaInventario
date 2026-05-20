

using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Entities
{
    public class AlmacenProducto
    {
        public int AlmacenId { get; set; }
        public Almacen Almacen { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
