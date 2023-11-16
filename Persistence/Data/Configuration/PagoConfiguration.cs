using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PagoConfiguration : IEntityTypeConfiguration<Pago>
{
    public void Configure(EntityTypeBuilder<Pago> builder)
    {
        builder.HasKey(e => e.CodigoPago).HasName("PRIMARY");

        builder.ToTable("pago");

        builder.Property(e => e.CodigoPago)
            .ValueGeneratedNever()
            .HasColumnName("codigo_pago");
        builder.Property(e => e.FechaPago)
            .HasColumnType("datetime")
            .HasColumnName("fecha_pago");
        builder.Property(e => e.FormaPago)
            .HasMaxLength(45)
            .HasColumnName("forma_pago");
        builder.Property(e => e.IdTransaccion).HasColumnName("id_transaccion");
        builder.Property(e => e.Total)
            .HasPrecision(15, 2)
            .HasColumnName("total");
    }
}