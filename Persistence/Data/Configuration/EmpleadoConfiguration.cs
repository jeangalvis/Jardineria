using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.HasKey(e => e.CodigoEmpleado).HasName("PRIMARY");

        builder.ToTable("empleado");

        builder.HasIndex(e => e.CodigoJefe, "fk_empleado_empleado1_idx");

        builder.HasIndex(e => e.CodigoOficina, "fk_empleado_oficina1_idx");

        builder.Property(e => e.CodigoEmpleado)
            .ValueGeneratedNever()
            .HasColumnName("codigo_empleado");
        builder.Property(e => e.Apellido1)
            .HasMaxLength(45)
            .HasColumnName("apellido1");
        builder.Property(e => e.Apellido2)
            .HasMaxLength(45)
            .HasColumnName("apellido2");
        builder.Property(e => e.CodigoJefe).HasColumnName("codigo_jefe");
        builder.Property(e => e.CodigoOficina)
            .HasMaxLength(10)
            .HasColumnName("codigo_oficina");
        builder.Property(e => e.Email)
            .HasMaxLength(45)
            .HasColumnName("email");
        builder.Property(e => e.Extension)
            .HasMaxLength(45)
            .HasColumnName("extension");
        builder.Property(e => e.Nombre)
            .HasMaxLength(45)
            .HasColumnName("nombre");
        builder.Property(e => e.Puesto)
            .HasMaxLength(45)
            .HasColumnName("puesto");

        builder.HasOne(d => d.CodigoJefeNavigation).WithMany(p => p.InverseCodigoJefeNavigation)
            .HasForeignKey(d => d.CodigoJefe)
            .HasConstraintName("fk_empleado_jefe");

        builder.HasOne(d => d.CodigoOficinaNavigation).WithMany(p => p.Empleados)
            .HasForeignKey(d => d.CodigoOficina)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_empleado_oficina1");
    }
}