using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public int Clienteid { get; set; }

        [ForeignKey("Clienteid")]
        public virtual Cliente Cliente { get; set; }
        public decimal Total { get; set; }

        public DateOnly Fechainicio { get; set; }
        public DateOnly Fechalimite { get; set; }
 
        public virtual ICollection<DetalleFactura> Detalles { get; set; }

    }
}
