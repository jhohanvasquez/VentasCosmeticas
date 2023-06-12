using SistemaVentaCosmeticos.Models;

namespace SistemaVentaCosmeticos.Repository.Contratos
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> Lista();
    }
}
