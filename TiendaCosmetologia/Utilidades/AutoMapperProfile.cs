using AutoMapper;
using SistemaVentaCosmeticos.DTOs;
using SistemaVentaCosmeticos.Models;
using System.Globalization;

namespace SistemaVentaCosmeticos.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.rolDescripcion,
                    opt => opt.MapFrom(origen => origen.IdRolNavigation.Descripcion)
                );

            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
            );
            #endregion Usuario

            #region DepartamentoVenta
            CreateMap<DepartamentoVenta, DepartamentoVentaDTO>().ReverseMap();
            #endregion DepartamentoVenta


            #region Producto
        CreateMap<Producto, ProductoDTO>()
            .ForMember(destino =>
                destino.DescripcionDepartamentoVenta,
                opt => opt.MapFrom(origen => origen.IdDepartamentoVentaNavigation.Descripcion)
            )
            .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            );

            CreateMap<ProductoDTO, Producto>()
            .ForMember(destino =>
                destino.IdDepartamentoVentaNavigation,
                opt => opt.Ignore()
            )
            .ForMember(destiono =>
                destiono.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
            );
            #endregion Producto


            #region Venta
            CreateMap<Venta, VentaDTO>()
                .ForMember(destino =>
                    destino.TotalTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                ).ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<VentaDTO, Venta>()
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
                );

            #endregion Venta


            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.PrecioTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.TotalTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );

            CreateMap<DetalleVentaDTO, DetalleVenta>()
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
                );
            #endregion

        }

    }
}
