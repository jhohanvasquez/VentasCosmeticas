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
                return await connection.QueryAsync<Producto>("SPCrearProducto", null, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<Producto>> Consultar(int idProducto)
        {
            using (var connection = _context.CreateConnection())
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdProducto", idProducto);
                
                return await connection.QueryAsync<Producto>("SPCrearProductoId", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<Producto>> Crear(Producto entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("IdProducto", entidad.IdProducto);
                    parameters.Add("Nombre", entidad.Nombre);
                    parameters.Add("Color", entidad.Color);
                    parameters.Add("IdDepartamentoVenta", entidad.IdDepartamentoVenta);
                    parameters.Add("Stock", entidad.Stock);
                    parameters.Add("Precio", entidad.Precio);
                    parameters.Add("EsActivo", entidad.EsActivo);
                    parameters.Add("FechaRegistro", entidad.FechaRegistro);

                    return await connection.QueryAsync<Producto>("SPCrearProducto", parameters, commandType: CommandType.StoredProcedure);

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
                    parameters.Add("IdDepartamentoVenta", entidad.IdDepartamentoVenta);
                    parameters.Add("Stock", entidad.Stock);
                    parameters.Add("Precio", entidad.Precio);
                    parameters.Add("EsActivo", entidad.EsActivo);
                    parameters.Add("FechaRegistro", entidad.FechaRegistro);

                    var result = await connection.QueryAsync<Producto>("SPCEditarProducto", parameters, commandType: CommandType.StoredProcedure);

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
                    parameters.Add("IdUsuario", entidad.IdProducto);

                    var result = await connection.QueryAsync<Usuario>("SPEliminarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Producto>> Obtener(Expression<Func<Producto, bool>> filtro = null)
        {
            try
            {
                var query = $@"SELECT * FROM [Usuario]
                            {{where}}";

                using (var connection = _context.CreateConnection())
                {
                    var list = await connection.QueryAsync<Producto>(query, filtro);
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
