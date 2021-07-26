using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CRUD_Facturación.Modelo
{
    public partial class Datos_CRUDContext : DbContext
    {
        public Datos_CRUDContext()
        {
        }

        public Datos_CRUDContext(DbContextOptions<Datos_CRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G9DMIOD\\SQLEXPRESS;Database=Datos_CRUD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Nit);

                entity.Property(e => e.Nit).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Detalle_Factura");

                entity.Property(e => e.IdDetalle).HasColumnName("Id_Detalle");

                entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");

                entity.Property(e => e.IdProducto)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Id_Producto");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("money")
                    .HasColumnName("Precio_Unitario");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_Factura_Factura");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_Factura_Productos");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Factura");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Clientes");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Id_Producto");

                entity.Property(e => e.ExistenciaProducto).HasColumnName("Existencia_Producto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Precio_Compra");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Precio_Venta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
