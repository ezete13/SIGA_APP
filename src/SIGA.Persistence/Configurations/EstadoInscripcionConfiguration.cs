// SIGA.Persistence/Configurations/TiposEstadoInscripcionConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class EstadoInscripcionConfiguration : IEntityTypeConfiguration<EstadoInscripcion>
{
    public void Configure(EntityTypeBuilder<EstadoInscripcion> builder)
    {
        builder.HasKey(e => e.Id).HasName("estados_inscripcion_pkey");

        builder.ToTable(
            "estados_inscripcion",
            tb => tb.HasComment("Catálogo de posibles estados que puede tener una inscripción.")
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
            .HasComment("Nombre del estado. Ej: Preinscripto, Confirmado, Aprobado.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción del tipo de estado.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("Activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

        builder
            .HasMany(t => t.Inscripciones)
            .WithOne(i => i.EstadoInscripcion)
            .HasForeignKey(i => i.EstadoInscripcionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(e => e.Codigo)
            .IsUnique()
            .HasDatabaseName("estados_inscripcion_codigo_key");

        builder.HasIndex(e => e.Activo).HasDatabaseName("IX_tipos_estado_inscripcion_estado");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_tipos_estado_inscripcion_nombre");
    }
}
