using SistemaVentaCosmeticos.Models;

namespace SistemaVentaCosmeticos.Repository.Contratos
{
    public interface IDepartamentoVentaRepositorio
    {
        Task<List<DepartamentoVenta>> Lista();
    }
}
