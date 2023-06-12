using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
