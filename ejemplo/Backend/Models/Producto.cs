using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    [Table("Producto")]
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

    }
}
