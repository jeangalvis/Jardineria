using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(e => e.CodigoProducto).HasName("PRIMARY");

        builder.ToTable("producto");

        builder.HasIndex(e => e.IdGama, "fk_producto_gama_producto1_idx");

        builder.Property(e => e.CodigoProducto)
            .HasMaxLength(15)
            .HasColumnName("codigo_producto");
        builder.Property(e => e.CantidadStock).HasColumnName("cantidad_stock");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(45)
            .HasColumnName("descripcion");
        builder.Property(e => e.Dimensiones)
            .HasMaxLength(45)
            .HasColumnName("dimensiones");
        builder.Property(e => e.IdGama).HasColumnName("id_gama");
        builder.Property(e => e.Nombre)
            .HasMaxLength(45)
            .HasColumnName("nombre");
        builder.Property(e => e.PrecioActual)
            .HasPrecision(15, 2)
            .HasColumnName("precio_actual");
        builder.Property(e => e.Proveedor).HasColumnName("proveedor");

        builder.HasOne(d => d.IdGamaNavigation).WithMany(p => p.Productos)
            .HasForeignKey(d => d.IdGama)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_producto_gama_producto1");
    }
}