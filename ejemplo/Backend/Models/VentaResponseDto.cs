namespace CRUD.Models
{
    /// <summary>
    /// DTO de respuesta de venta. Devuelve IDs y nombres (no los objetos completos).
    /// </summary>
    public class VentaResponseDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Clienteid { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public int Productoid { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
