using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class DepartamentoVentaRepositorio : IDepartamentoVentaRepositorio
    {
        private readonly DBVentaCosmeticosContext _dbContext;

        public DepartamentoVentaRepositorio(DBVentaCosmeticosContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<DepartamentoVenta>> Lista()
        {
            try
            {
                return await _dbContext.DepartamentoVenta.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
