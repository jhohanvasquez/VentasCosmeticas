using Dapper;
using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Data;
using System.Globalization;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly DBVentaCosmeticosContext _dbcontext;

        private readonly IProductoRepositorio _dbproducto;
        public VentaRepositorio(DBVentaCosmeticosContext context, IProductoRepositorio dbproducto)
        {
            this._dbcontext = context;
            this._dbproducto = dbproducto;
        }

        public async Task<Venta> Registrar(Venta entidad)
        {
            Venta VentaGenerada = new Venta();

            try
            {
                foreach (DetalleVenta dv in entidad.DetalleVenta)
                {
                    Producto producto_encontrado = await _dbproducto.Consultar(dv.IdProducto);

                    producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                    await _dbproducto.Editar(producto_encontrado);
                }

                entidad.NumeroDocumento = Guid.NewGuid().ToString();
                entidad.FechaRegistro = DateTime.Now;

                using (var connection = _dbcontext.CreateConnection())
                {

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("NumeroDocumento", entidad.NumeroDocumento);
                    parameters.Add("TipoPago", entidad.TipoPago);
                    parameters.Add("FechaRegistro", entidad.FechaRegistro);
                    parameters.Add("Total", entidad.Total);

                    var result = await connection.ExecuteScalarAsync<int>("SP_CrearVenta", parameters, commandType: CommandType.StoredProcedure);
                    entidad.IdVenta = result;                   
                }

                VentaGenerada = entidad;
            }
            catch (Exception ex)
            {
                throw;
            }

            return VentaGenerada;
        }

    }
}
