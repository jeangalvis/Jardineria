using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(e => e.IdCliente).HasName("PRIMARY");

        builder.ToTable("cliente");

        builder.Property(e => e.IdCliente)
            .ValueGeneratedNever()
            .HasColumnName("id_cliente");
        builder.Property(e => e.ApellidoContacto)
            .HasMaxLength(45)
            .HasColumnName("apellido_contacto");
        builder.Property(e => e.Ciudad)
            .HasMaxLength(45)
            .HasColumnName("ciudad");
        builder.Property(e => e.CodigoPostal)
            .HasMaxLength(45)
            .HasColumnName("codigo_postal");
        builder.Property(e => e.Fax)
            .HasMaxLength(45)
            .HasColumnName("fax");
        builder.Property(e => e.LimiteCredito)
            .HasPrecision(15, 2)
            .HasColumnName("limite_credito");
        builder.Property(e => e.LineaDireccion1)
            .HasMaxLength(45)
            .HasColumnName("linea_direccion1");
        builder.Property(e => e.LineaDireccion2)
            .HasMaxLength(45)
            .HasColumnName("linea_direccion2");
        builder.Property(e => e.NombreCliente)
            .HasMaxLength(45)
            .HasColumnName("nombre_cliente");
        builder.Property(e => e.NombreContacto)
            .HasMaxLength(45)
            .HasColumnName("nombre_contacto");
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