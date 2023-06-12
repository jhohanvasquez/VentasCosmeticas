using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Linq.Expressions;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly DBVentaCosmeticosContext _dbContext;

        public RolRepositorio(DBVentaCosmeticosContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _dbContext.Rols.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
