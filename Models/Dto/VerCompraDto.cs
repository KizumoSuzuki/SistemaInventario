using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Dto
{
    public class VerCompraDto
    {
        public int Id { get; set; }
        public int Proveedorid { get; set; }
        public string ProveedorNombre { get; set; }
        public int Almacenid { get; set; }
        public string AlmacenNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        
        public List<VerDetalleCompraDto> Detalles { get; set; }
    }
}
