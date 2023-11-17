using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
{
    public void Configure(EntityTypeBuilder<DetallePedido> builder)
    {
        builder.HasKey(e => e.IdDetallePedido).HasName("PRIMARY");

        builder.ToTable("detalle_pedido");

        builder.HasIndex(e => e.CodigoPedido, "fk_detalle_pedido_pedido_idx");

        builder.HasIndex(e => e.CodigoProducto, "fk_detalle_pedido_producto1_idx");

        builder.Property(e => e.IdDetallePedido)
            .HasMaxLength(45)
            .HasColumnName("id_detalle_pedido");
        builder.Property(e => e.Cantidad).HasColumnName("cantidad");
        builder.Property(e => e.CodigoPedido).HasColumnName("codigo_pedido");
        builder.Property(e => e.CodigoProducto)
            .HasMaxLength(15)
            .HasColumnName("codigo_producto");
        builder.Property(e => e.NumeroLinea).HasColumnName("numero_linea");
        builder.Property(e => e.PrecioUnidad)
            .HasPrecision(15, 2)
            .HasColumnName("precio_unidad");

        builder.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.DetallePedidos)
            .HasForeignKey(d => d.CodigoPedido)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_detalle_pedido_pedido");

        builder.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetallePedidos)
            .HasForeignKey(d => d.CodigoProducto)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_detalle_pedido_producto1");
    }
}