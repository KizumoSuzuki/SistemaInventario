using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models
{
    public class DetalleFactura
    {

        public int Id { get; set; }
        public int Facturaid { get; set; }
        [ForeignKey("Facturaid")]
        public virtual Factura Factura { get; set; }
        public int Productoid { get; set; }
        [ForeignKey("Productoid")]
        public virtual Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal  => Cantidad*PrecioUnitario;

    }
}
