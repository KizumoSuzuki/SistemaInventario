using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public int Productoid { get; set; }
        [ForeignKey("Productoid")]
        public virtual Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public string TipoMovimiento { get; set; } 

        public DateTime Fecha { get; set; }

    }
}
