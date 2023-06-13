using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Globalization;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly DBVentaCosmeticosContext _dbcontext;
        public VentaRepositorio(DBVentaCosmeticosContext context)
        {
            _dbcontext = context;
        }

        public async Task<Venta> Registrar(Venta entidad)
        {
            Venta VentaGenerada = new Venta();

            int CantidadDigitos = 4;
            //try
            //{
            //    foreach (DetalleVenta dv in entidad.DetalleVenta)
            //    {
            //        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

            //        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
            //        _dbcontext.Productos.Update(producto_encontrado);
            //    }
            //    await _dbcontext.SaveChangesAsync();


            //    NumeroDocumento correlativo = _dbcontext.NumeroDocumentos.First();

            //    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
            //    correlativo.FechaRegistro = DateTime.Now;

            //    _dbcontext.NumeroDocumentos.Update(correlativo);
            //    await _dbcontext.SaveChangesAsync();


            //    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
            //    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
            //    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

            //    entidad.NumeroDocumento = numeroVenta;

            //    await _dbcontext.Venta.AddAsync(entidad);
            //    await _dbcontext.SaveChangesAsync();

            //    VentaGenerada = entidad;

            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            return VentaGenerada;
        }

    }
}
