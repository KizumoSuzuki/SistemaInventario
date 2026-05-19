using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    public class DetalleCompra
    {
        [Key]
        public int Id { get; set; }
        
        public int Compraid { get; set; }
        [ForeignKey("Compraid")]
        public virtual Compra Compra { get; set; }

        public int Productoid { get; set; }
        [ForeignKey("Productoid")]
        public virtual Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal SubTotal => Cantidad * PrecioCompra;
    }
}
