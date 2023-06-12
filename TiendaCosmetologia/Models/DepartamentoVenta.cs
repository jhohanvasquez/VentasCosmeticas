using System;
using System.Collections.Generic;

namespace SistemaVentaCosmeticos.Models
{
    public partial class DepartamentoVenta
    {
        public DepartamentoVenta()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdDepartamentoVenta { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
