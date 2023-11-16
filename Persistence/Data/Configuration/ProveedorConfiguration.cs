using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.HasKey(e => e.IdProveedor).HasName("PRIMARY");

        builder.ToTable("proveedor");

        builder.Property(e => e.IdProveedor)
            .ValueGeneratedNever()
            .HasColumnName("id_proveedor");
        builder.Property(e => e.Nombre)
            .HasMaxLength(45)
            .HasColumnName("nombre");
    }
}