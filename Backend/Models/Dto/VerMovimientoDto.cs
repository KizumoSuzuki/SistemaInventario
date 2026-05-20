using SistemaInventario.Enums;

namespace SistemaInventario.Models.Dto
{
    public class VerMovimientoDto
    {
        public int Id { get; set; }
        public int Productoid { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuarioid { get; set; }
        public string UsuarioNombre { get; set; }
    }
}
