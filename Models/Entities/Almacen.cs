using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Entities
{
    public class Almacen
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Capacidad { get; set; }
        public ICollection<AlmacenProducto> AlmacenProductos { get; set; } = new List<AlmacenProducto>();
    }
}
