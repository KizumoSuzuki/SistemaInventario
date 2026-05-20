using System.Collections.Generic;

namespace SistemaInventario.Models.Dto
{
    public class VerAlmacenDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Capacidad { get; set; }
        public List<ProductoEnAlmacenDto> Productos { get; set; } = new List<ProductoEnAlmacenDto>();
    }
}
