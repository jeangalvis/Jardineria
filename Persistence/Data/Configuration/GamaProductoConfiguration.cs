using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class GamaProductoConfiguration : IEntityTypeConfiguration<GamaProducto>
{
    public void Configure(EntityTypeBuilder<GamaProducto> builder)
    {
        builder.HasKey(e => e.IdGama).HasName("PRIMARY");

        builder.ToTable("gama_producto");

        builder.Property(e => e.IdGama)
            .ValueGeneratedNever()
            .HasColumnName("id_gama");
        builder.Property(e => e.DescripcionHtml)
            .HasColumnType("tinytext")
            .HasColumnName("descripcion_html");
        builder.Property(e => e.DescripcionTexto)
            .HasColumnType("tinytext")
            .HasColumnName("descripcion_texto");
        builder.Property(e => e.Imagen)
            .HasMaxLength(256)
            .HasColumnName("imagen");
    }
}