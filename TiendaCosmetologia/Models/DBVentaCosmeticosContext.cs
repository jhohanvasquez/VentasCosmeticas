﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SistemaVentaCosmeticos.Models
{
    public partial class DBVentaCosmeticosContext : DbContext
    {
        public DBVentaCosmeticosContext()
        {
        }

        public DBVentaCosmeticosContext(DbContextOptions<DBVentaCosmeticosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartamentoVenta> DepartamentoVenta { get; set; } = null!;
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; } = null!;
        public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Venta> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.DepartamentoVenta", b =>
            {
                b.Property<int>("IdDepartamentoVenta")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idDepartamentoVenta");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamentoVenta"), 1L, 1);

                b.Property<string>("Descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("descripcion");

                b.Property<bool?>("EsActivo")
                    .HasColumnType("bit")
                    .HasColumnName("esActivo");

                b.Property<DateTime?>("FechaRegistro")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                b.HasKey("IdDepartamentoVenta")
                    .HasName("PK__Categori__8A3D240CE670682C");

                b.ToTable("DepartamentoVenta");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.DetalleVenta", b =>
            {
                b.Property<int>("IdDetalleVenta")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idDetalleVenta");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleVenta"), 1L, 1);

                b.Property<int?>("Cantidad")
                    .HasColumnType("int")
                    .HasColumnName("cantidad");

                b.Property<int?>("IdProducto")
                    .HasColumnType("int")
                    .HasColumnName("idProducto");

                b.Property<int?>("IdVenta")
                    .HasColumnType("int")
                    .HasColumnName("idVenta");

                b.Property<decimal?>("Precio")
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("precio");

                b.Property<decimal?>("Total")
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("total");

                b.HasKey("IdDetalleVenta")
                    .HasName("PK__DetalleV__BFE2843FA3FFCC43");

                b.HasIndex("IdProducto");

                b.HasIndex("IdVenta");

                b.ToTable("DetalleVenta");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.NumeroDocumento", b =>
            {
                b.Property<int>("IdNumeroDocumento")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idNumeroDocumento");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNumeroDocumento"), 1L, 1);

                b.Property<DateTime?>("FechaRegistro")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                b.Property<int>("UltimoNumero")
                    .HasColumnType("int")
                    .HasColumnName("ultimo_Numero");

                b.HasKey("IdNumeroDocumento")
                    .HasName("PK__NumeroDo__471E421A78999DD9");

                b.ToTable("NumeroDocumento", (string)null);
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Producto", b =>
            {
                b.Property<int>("IdProducto")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idProducto");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"), 1L, 1);

                b.Property<bool?>("EsActivo")
                    .HasColumnType("bit")
                    .HasColumnName("esActivo");

                b.Property<DateTime?>("FechaRegistro")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                b.Property<int?>("IdDepartamentoVenta")
                    .HasColumnType("int")
                    .HasColumnName("idDepartamentoVenta");

                b.Property<string>("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("nombre");

                b.Property<decimal?>("Precio")
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("precio");

                b.Property<int?>("Stock")
                    .HasColumnType("int")
                    .HasColumnName("stock");

                b.HasKey("IdProducto")
                    .HasName("PK__Producto__07F4A1323E322568");

                b.HasIndex("IdDepartamentoVenta");

                b.ToTable("Producto", (string)null);
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Rol", b =>
            {
                b.Property<int>("IdRol")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idRol");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                b.Property<string>("Descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("descripcion");

                b.Property<bool?>("EsActivo")
                    .HasColumnType("bit")
                    .HasColumnName("esActivo");

                b.Property<DateTime?>("FechaRegistro")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                b.HasKey("IdRol")
                    .HasName("PK__Rol__3C872F7670BFFF74");

                b.ToTable("Rol", (string)null);
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Usuario", b =>
            {
                b.Property<int>("IdUsuario")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idUsuario");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                b.Property<string>("Clave")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("clave");

                b.Property<string>("Correo")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("correo");

                b.Property<bool?>("EsActivo")
                    .HasColumnType("bit")
                    .HasColumnName("esActivo");

                b.Property<int?>("IdRol")
                    .HasColumnType("int")
                    .HasColumnName("idRol");

                b.Property<string>("NombreApellidos")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("nombreApellidos");

                b.HasKey("IdUsuario")
                    .HasName("PK__Usuario__645723A61F6FD7E7");

                b.HasIndex("IdRol");

                b.ToTable("Usuario", (string)null);
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Venta", b =>
            {
                b.Property<int>("IdVenta")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("idVenta");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"), 1L, 1);

                b.Property<DateTime?>("FechaRegistro")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                b.Property<string>("NumeroDocumento")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("numeroDocumento");

                b.Property<string>("TipoPago")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("tipoPago");

                b.Property<decimal?>("Total")
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("total");

                b.HasKey("IdVenta")
                    .HasName("PK__Venta__077D561409C275F1");

                b.ToTable("Venta");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.DetalleVenta", b =>
            {
                b.HasOne("SistemaVentaCosmeticos.Models.Producto", "IdProductoNavigation")
                    .WithMany("DetalleVenta")
                    .HasForeignKey("IdProducto")
                    .HasConstraintName("FK__DetalleVe__idPro__267ABA7A");

                b.HasOne("SistemaVentaCosmeticos.Models.Venta", "IdVentaNavigation")
                    .WithMany("DetalleVenta")
                    .HasForeignKey("IdVenta")
                    .HasConstraintName("FK__DetalleVe__idVen__25869641");

                b.Navigation("IdProductoNavigation");

                b.Navigation("IdVentaNavigation");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Producto", b =>
            {
                b.HasOne("SistemaVentaCosmeticos.Models.DepartamentoVenta", "IdDepartamentoVentaNavigation")
                    .WithMany("Productos")
                    .HasForeignKey("IdDepartamentoVenta")
                    .HasConstraintName("FK__Producto__idCate__1BFD2C07");

                b.Navigation("IdDepartamentoVentaNavigation");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Usuario", b =>
            {
                b.HasOne("SistemaVentaCosmeticos.Models.Rol", "IdRolNavigation")
                    .WithMany("Usuarios")
                    .HasForeignKey("IdRol")
                    .HasConstraintName("FK__Usuario__idRol__164452B1");

                b.Navigation("IdRolNavigation");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.DepartamentoVenta", b =>
            {
                b.Navigation("Productos");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Producto", b =>
            {
                b.Navigation("DetalleVenta");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Rol", b =>
            {
                b.Navigation("Usuarios");
            });

            modelBuilder.Entity("SistemaVentaCosmeticos.Models.Venta", b =>
            {
                b.Navigation("DetalleVenta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
