using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Globalization;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class DashBoardRepositorio : IDashBoardRepositorio
    {
        private readonly DBVentaCosmeticosContext _dbcontext;
        public DashBoardRepositorio(DBVentaCosmeticosContext context)
        {
            _dbcontext = context;
        }
        public async Task<int> TotalProductos()
        {
            try
            {
                IQueryable<Producto> query = _dbcontext.Productos;
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }
    }
}
