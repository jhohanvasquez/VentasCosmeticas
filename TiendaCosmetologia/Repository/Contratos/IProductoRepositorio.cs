using SistemaVentaCosmeticos.Models;
using System.Linq.Expressions;

namespace SistemaVentaCosmeticos.Repository.Contratos
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> Crear(Producto entidad);
        Task<bool> Editar(Producto entidad);
        Task<bool> Eliminar(Producto entidad);
        Task<IEnumerable<Producto>> Consultar();
        Task<IEnumerable<Producto>> Consultar(int id);
    }
}
