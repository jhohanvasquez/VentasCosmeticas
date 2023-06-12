using SistemaVentaCosmeticos.Models;
using System.Linq.Expressions;

namespace SistemaVentaCosmeticos.Repository.Contratos
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> Lista();
        Task<IEnumerable<Usuario>> Obtener(string email, string clave);
        Task<IEnumerable<Usuario>> Obtener(int idUsuario);
        Task<IEnumerable<Usuario>> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
        Task<IEnumerable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null);
    }
}
