namespace CRUD.Models
{
    /// <summary>
    /// DTO para crear una venta. Solo pide los IDs del cliente y producto.
    /// </summary>
    public class VentaCreateDto
    {
        public int Clienteid { get; set; }
        public int Productoid { get; set; }
    }
}
