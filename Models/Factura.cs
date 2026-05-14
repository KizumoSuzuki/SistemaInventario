using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int Clienteid { get; set; }

        [ForeignKey("Clienteid")]
        public virtual Cliente Cliente { get; set; }
        public decimal Total { get; set; }

        public DateOnly Fechainicio { get; set; }
        public DateOnly Fechalimite { get; set; }
        public int Productoid { get; set; }

        [ForeignKey("Productoid")]
        public virtual Producto Producto { get; set; }
        




    }
}
