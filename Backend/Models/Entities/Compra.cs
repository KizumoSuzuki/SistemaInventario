using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        
        public int Proveedorid { get; set; }
        [ForeignKey("Proveedorid")]
        public virtual Proveedor Proveedor { get; set; }

        public int Almacenid { get; set; }
        [ForeignKey("Almacenid")]
        public virtual Almacen Almacen { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<DetalleCompra> Detalles { get; set; }
    }
}
