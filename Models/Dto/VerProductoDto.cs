using SistemaInventario.Enums;

namespace SistemaInventario.Models.Dto
{
    public class VerProductoDto
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public int Categoriaid { get; set; }
        public string CategoriaNombre { get; set; }
        public int Proveedorid { get; set; }
        public string ProveedorNombre { get; set; }
    }
}
