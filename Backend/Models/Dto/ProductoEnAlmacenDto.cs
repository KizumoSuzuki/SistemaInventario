namespace SistemaInventario.Models.Dto
{
    public class ProductoEnAlmacenDto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int Stock { get; set; }
    }
}
