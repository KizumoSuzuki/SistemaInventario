namespace SistemaInventario.Models.Dto
{
    public class VerFacturaDto
    {
        public int Id { get; set; }
        public int Clienteid { get; set; }
        public string ClienteNombre { get; set; }
        public decimal Total { get; set; }
        public DateOnly Fechainicio { get; set; }
        public DateOnly Fechalimite { get; set; }
        public List<VerDetalleFacturaDto> Detalles { get; set; }
    }
}
