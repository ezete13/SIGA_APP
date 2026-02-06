// SIGA.Persistence/Configurations/PropuestaDocenteConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestaDocenteConfiguration : IEntityTypeConfiguration<PropuestaDocente>
{
    public void Configure(EntityTypeBuilder<PropuestaDocente> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuesta_docente_pkey");

        builder.ToTable(
            "propuesta_docente",
            tb =>
                tb.HasComment(
                    "Relación muchos a muchos entre propuestas y docentes, con información del rol en cada propuesta."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasComment("ID de la propuesta académica (FK a propuestas.id).");

        builder
            .Property(e => e.DocenteId)
            .HasColumnName("docente_id")
            .IsRequired()
            .HasComment("ID del docente/disertante (FK a docentes.id).");

        builder
            .Property(e => e.Rol)
            .HasColumnName("rol")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Rol del docente en la propuesta: Titular, Ayudante, Adjunto.");

        builder
            .Property(e => e.OrdenWeb)
            .HasColumnName("orden_web")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden de aparición en la web (para ordenar docentes).");

        // RELACIONES
        builder
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.PropuestaDocente)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("propuesta_docente_propuesta_id_fkey")
            .IsRequired();

        builder
            .HasOne(d => d.Docente)
            .WithMany(p => p.PropuestaDocente)
            .HasForeignKey(d => d.DocenteId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuesta_docente_docente_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => new { e.PropuestaId, e.DocenteId })
            .IsUnique()
            .HasDatabaseName("propuesta_docente_propuesta_id_docente_id_key");

        builder.HasIndex(e => e.PropuestaId).HasDatabaseName("IX_propuesta_docente_propuesta_id");

        builder.HasIndex(e => e.DocenteId).HasDatabaseName("IX_propuesta_docente_docente_id");

        builder.HasIndex(e => e.OrdenWeb).HasDatabaseName("IX_propuesta_docente_orden_web");
    }
}
