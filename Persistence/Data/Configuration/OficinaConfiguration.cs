using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class OficinaConfiguration : IEntityTypeConfiguration<Oficina>
{
    public void Configure(EntityTypeBuilder<Oficina> builder)
    {
        builder.HasKey(e => e.CodigoOficina).HasName("PRIMARY");

        builder.ToTable("oficina");

        builder.Property(e => e.CodigoOficina)
            .HasMaxLength(10)
            .HasColumnName("codigo_oficina");
        builder.Property(e => e.Ciudad)
            .HasMaxLength(45)
            .HasColumnName("ciudad");
        builder.Property(e => e.CodigoPostal)
            .HasMaxLength(45)
            .HasColumnName("codigo_postal");
        builder.Property(e => e.LineaDireccion1)
            .HasMaxLength(45)
            .HasColumnName("linea_direccion1");
        builder.Property(e => e.LineaDireccion2)
            .HasMaxLength(45)
            .HasColumnName("linea_direccion2");
        builder.Property(e => e.Pais)
            .HasMaxLength(45)
            .HasColumnName("pais");
        builder.Property(e => e.Region)
            .HasMaxLength(45)
            .HasColumnName("region");
        builder.Property(e => e.Telefono)
            .HasMaxLength(45)
            .HasColumnName("telefono");
    }
}