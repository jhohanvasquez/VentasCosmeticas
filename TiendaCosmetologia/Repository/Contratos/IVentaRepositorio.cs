using SistemaVentaCosmeticos.Models;

namespace SistemaVentaCosmeticos.Repository.Contratos
{
    public interface IVentaRepositorio
    {
        Task<Venta> Registrar(Venta entidad);
    }
}
