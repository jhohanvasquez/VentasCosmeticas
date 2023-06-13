using Dapper;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Data;
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
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<int>("SP_ConsultarProductos", null, commandType: CommandType.StoredProcedure);
                    return result.ToList().Count();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
