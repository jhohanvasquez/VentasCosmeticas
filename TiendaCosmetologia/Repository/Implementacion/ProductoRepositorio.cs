using Dapper;
using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Data;
using System.Linq.Expressions;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly DBVentaCosmeticosContext _context;

        public ProductoRepositorio(DBVentaCosmeticosContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Producto>> Consultar()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Producto>("SP_ConsultarProductos", null, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<Producto> Consultar(int? idProducto)
        {
            using (var connection = _context.CreateConnection())
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdProducto", idProducto);
                
                var result = await connection.QueryAsync<Producto>("SP_ConsultarProductosId", parameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Producto>> Crear(Producto entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Nombre", entidad.Nombre);
                    parameters.Add("Color", entidad.Color);
                    parameters.Add("IdPromocion", entidad.idPromocion);
                    parameters.Add("IdDepartamentoVenta", entidad.idDepartamentoVenta);
                    parameters.Add("Stock", entidad.Stock);
                    parameters.Add("Precio", entidad.Precio);
                    parameters.Add("EsActivo", entidad.EsActivo);
                    parameters.Add("FechaRegistro", entidad.FechaRegistro);

                    return await connection.QueryAsync<Producto>("SP_CrearProducto", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Producto entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("IdProducto", entidad.IdProducto);
                    parameters.Add("Nombre", entidad.Nombre);
                    parameters.Add("Color", entidad.Color);
                    parameters.Add("IdPromocion", entidad.idPromocion);
                    parameters.Add("IdDepartamentoVenta", entidad.idDepartamentoVenta);
                    parameters.Add("Stock", entidad.Stock);
                    parameters.Add("Precio", entidad.Precio);
                    parameters.Add("EsActivo", entidad.EsActivo);
                    parameters.Add("FechaRegistro", entidad.FechaRegistro);

                    var result = await connection.QueryAsync<Producto>("SP_EditarProducto", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Producto entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("IdProducto", entidad.IdProducto);

                    var result = await connection.QueryAsync<Usuario>("SP_EliminarProducto", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
