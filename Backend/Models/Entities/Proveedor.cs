using SistemaInventario.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.Entities
{
    public class Proveedor
    {
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RNC { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public Estado Estado   { get; set; }
    }
}
