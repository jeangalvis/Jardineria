using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(e => e.CodigoPedido).HasName("PRIMARY");

        builder.ToTable("pedido");

        builder.HasIndex(e => e.CodigoCliente, "fk_pedido_cliente1_idx");

        builder.HasIndex(e => e.CodigoEmpleado, "fk_pedido_empleado1_idx");

        builder.HasIndex(e => e.CodigoPago, "fk_pedido_pago1_idx");

        builder.Property(e => e.CodigoPedido)
            .ValueGeneratedNever()
            .HasColumnName("codigo_pedido");
        builder.Property(e => e.CodigoCliente).HasColumnName("codigo_cliente");
        builder.Property(e => e.CodigoEmpleado).HasColumnName("codigo_empleado");
        builder.Property(e => e.CodigoPago).HasColumnName("codigo_pago");
        builder.Property(e => e.Comentarios)
            .HasColumnType("text")
            .HasColumnName("comentarios");
        builder.Property(e => e.Estado)
            .HasMaxLength(45)
            .HasColumnName("estado");
        builder.Property(e => e.FechaEntrega)
            .HasMaxLength(45)
            .HasColumnName("fecha_entrega");
        builder.Property(e => e.FechaEsperada)
            .HasColumnType("datetime")
            .HasColumnName("fecha_esperada");
        builder.Property(e => e.FechaPedido)
            .HasColumnType("datetime")
            .HasColumnName("fecha_pedido");

        builder.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.CodigoCliente)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_pedido_cliente1");

        builder.HasOne(d => d.CodigoEmpleadoNavigation).WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.CodigoEmpleado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_pedido_empleado1");

        builder.HasOne(d => d.CodigoPagoNavigation).WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.CodigoPago)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_pedido_pago1");
    }
}