using Dapper;
using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Linq.Expressions;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly DBVentaCosmeticosContext _context;

        public RolRepositorio(DBVentaCosmeticosContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                var query = "SELECT * FROM Rol";
                using (var connection = _context.CreateConnection())
                {
                    var rols = await connection.QueryAsync<Rol>(query);
                    return rols.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
