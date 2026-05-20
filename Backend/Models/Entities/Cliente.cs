using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RNC { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
