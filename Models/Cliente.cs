using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RNC { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
