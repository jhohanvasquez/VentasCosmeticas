using Dapper;
using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Data;
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
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<Rol>("SP_ListarUsuario", null, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
