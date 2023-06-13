namespace SistemaVentaCosmeticos.DTOs
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Color { get; set; }
        public int? IdDepartamentoVenta { get; set; }
        public string? DescripcionDepartamentoVenta { get; set; }
        public int? Stock { get; set; }
        public string? Precio { get; set; }
    }
}
