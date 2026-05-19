namespace SistemaInventario.Models.Dto
{
    public class VerDetalleCompraDto
    {
        public int Id { get; set; }
        public int Productoid { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal SubTotal { get; set; }
    }
}
