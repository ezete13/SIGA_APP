// SIGA.Persistence/Configurations/HistorialEstadoPropuestasConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class HistorialEstadoPropuestasConfiguration
    : IEntityTypeConfiguration<HistorialEstadoPropuestas>
{
    public void Configure(EntityTypeBuilder<HistorialEstadoPropuestas> builder)
    {
        // ESTA tabla SÍ tiene clave primaria
        builder.HasKey(e => e.Id).HasName("historial_estado_propuestas_pkey");

        builder.ToTable("historial_estado_propuestas");

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasComment("ID de la propuesta cuyo estado cambió.");

        builder
            .Property(e => e.TipoEstadoPropuestaId)
            .HasColumnName("tipo_estado_propuesta_id")
            .IsRequired()
            .HasComment("ID del nuevo estado de la propuesta.");

        builder
            .Property(e => e.UsuarioId)
            .HasColumnName("usuario_id")
            .IsRequired(false) // Nullable
            .HasComment("ID del usuario que realizó el cambio (opcional).");

        builder
            .Property(e => e.Observaciones)
            .HasColumnName("observaciones")
            .IsRequired(false) // Nullable
            .HasComment("Observaciones o comentarios sobre el cambio de estado.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasComment("Fecha y hora del cambio de estado.");

        // RELACIÓN con Propuesta (CON navegación inversa)
        builder
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.HistorialEstadoPropuestas)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("historial_estado_propuestas_propuesta_id_fkey")
            .IsRequired();

        // RELACIÓN con TipoEstadoPropuesta (CON navegación inversa)
        builder
            .HasOne(d => d.TipoEstadoPropuesta)
            .WithMany(p => p.HistorialEstadoPropuestas)
            .HasForeignKey(d => d.TipoEstadoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("historial_estado_propuestas_tipo_estado_propuesta_id_fkey")
            .IsRequired();

        // RELACIÓN con Usuario (CON navegación inversa)
        builder
            .HasOne(d => d.Usuario)
            .WithMany(p => p.HistorialEstadoPropuestas)
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("historial_estado_propuestas_usuario_id_fkey");

        // ÍNDICES
        builder
            .HasIndex(e => e.PropuestaId)
            .HasDatabaseName("IX_historial_propuestas_propuesta_id");

        builder.HasIndex(e => e.CreadoEn).HasDatabaseName("IX_historial_propuestas_creado_en");

        builder
            .HasIndex(e => new { e.PropuestaId, e.CreadoEn })
            .HasDatabaseName("IX_historial_propuestas_propuesta_fecha")
            .IsDescending(false, true);

        // Índice para búsqueda por usuario
        builder
            .HasIndex(e => e.UsuarioId)
            .HasDatabaseName("IX_historial_propuestas_usuario_id")
            .HasFilter("usuario_id IS NOT NULL");
    }
}
