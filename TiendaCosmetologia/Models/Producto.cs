using System;
using System.Collections.Generic;

namespace SistemaVentaCosmeticos.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Color { get; set; }
        public int? IdDepartamentoVenta { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual DepartamentoVenta? IdDepartamentoVentaNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
