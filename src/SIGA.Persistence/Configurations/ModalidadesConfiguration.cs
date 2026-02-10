// SIGA.Persistence/Configurations/ModalidadesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class ModalidadConfiguration : IEntityTypeConfiguration<Modalidad>
{
    public void Configure(EntityTypeBuilder<Modalidad> builder)
    {
        builder.HasKey(e => e.Id).HasName("modalidades_pkey");

        builder.ToTable(
            "modalidades",
            tb =>
                tb.HasComment(
                    "Modalidades que un curso o jornada puede tener (presencial, virtual, híbrido)."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(10)
            .IsRequired()
            .HasComment("Código interno único.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Nombre de la modalidad. Ej: Presencial, Virtual, Híbrido.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción detallada de la modalidad.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired(false)
            .HasComment("Estado activo/inactivo (true=activa, false=inactiva).");

        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("modalidades_codigo_key");

        builder.HasIndex(e => e.Nombre).IsUnique().HasDatabaseName("modalidades_nombre_key");

        builder.HasIndex(e => e.Activo).HasDatabaseName("IX_modalidades_estado");

        builder
            .HasMany(m => m.Propuestas)
            .WithOne(p => p.Modalidad)
            .HasForeignKey(p => p.ModalidadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
