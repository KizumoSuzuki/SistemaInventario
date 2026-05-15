using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Compra { get; set; }
        public decimal Venta { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public int Stock { get; set; }
        public int Categoriaid { get; set; }

        [ForeignKey("Categoriaid")]
        public virtual Categoria Categoria { get; set; }
        public int Proveedorid { get; set; }
        [ForeignKey("Proveedorid")]
        public virtual Proveedor Proveedor { get; set; }
    }
}
