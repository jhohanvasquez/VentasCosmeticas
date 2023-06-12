using Dapper;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Globalization;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class DashBoardRepositorio : IDashBoardRepositorio
    {
        private readonly DBVentaCosmeticosContext _context;
        public DashBoardRepositorio(DBVentaCosmeticosContext context)
        {
            _context = context;
        }
        public async Task<int> TotalProductos()
        {
            try
            {
                var query = "SELECT * FROM Productos";
                using (var connection = _context.CreateConnection())
                {
                    var companies = await connection.QueryAsync<Producto>(query);
                    return companies.ToList().Count();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
