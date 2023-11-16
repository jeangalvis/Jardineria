using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProveedorProductoConfiguration : IEntityTypeConfiguration<ProveedorProducto>
{
    public void Configure(EntityTypeBuilder<ProveedorProducto> builder)
    {
        builder.HasKey(e => e.IdProvprod).HasName("PRIMARY");

        builder.ToTable("proveedor_producto");

        builder.HasIndex(e => e.ProductoCodigoProducto, "fk_proveedor_producto_producto1_idx");

        builder.HasIndex(e => e.ProveedorId, "fk_proveedor_producto_proveedor1_idx");

        builder.Property(e => e.IdProvprod)
            .ValueGeneratedNever()
            .HasColumnName("id_provprod");
        builder.Property(e => e.PrecioProveedor)
            .HasPrecision(15, 2)
            .HasColumnName("precio_proveedor");
        builder.Property(e => e.ProductoCodigoProducto)
            .HasMaxLength(15)
            .HasColumnName("producto_codigo_producto");
        builder.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

        builder.HasOne(d => d.ProductoCodigoProductoNavigation).WithMany(p => p.ProveedorProductos)
            .HasForeignKey(d => d.ProductoCodigoProducto)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_proveedor_producto_producto1");

        builder.HasOne(d => d.Proveedor).WithMany(p => p.ProveedorProductos)
            .HasForeignKey(d => d.ProveedorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_proveedor_producto_proveedor1");
    }
}