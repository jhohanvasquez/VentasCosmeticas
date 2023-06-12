using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using Dapper;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class DepartamentoVentaRepositorio : IDepartamentoVentaRepositorio
    {
        private readonly DBVentaCosmeticosContext _context;

        public DepartamentoVentaRepositorio(DBVentaCosmeticosContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<DepartamentoVenta>> Lista()
        {
            try
            {
                var query = "SELECT * FROM DepartamentoVenta";
                using (var connection = _context.CreateConnection())
                {
                    var companies = await connection.QueryAsync<DepartamentoVenta>(query);
                    return companies.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
