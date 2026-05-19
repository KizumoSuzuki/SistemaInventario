using System.ComponentModel.DataAnnotations.Schema; // <--- Esta es la clave

namespace CRUD.Models
{
    public class Ventas
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        // 1. Esta es la columna REAL que está en SQL
        public int Clienteid { get; set; }

        // 2. Esta es la relación (Navegación). 
        // Usamos [ForeignKey] para decirle que use 'Clienteid' y no busque una columna 'Cliente'
        [ForeignKey("Clienteid")]
        public virtual Cliente? Cliente { get; set; }

        public int Productoid { get; set; }

        [ForeignKey("Productoid")]
        public virtual Producto? Producto { get; set; }

        public decimal Total { get; set; }
    }
}
