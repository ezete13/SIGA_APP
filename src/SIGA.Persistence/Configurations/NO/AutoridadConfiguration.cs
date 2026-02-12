// SIGA.Persistence/Configurations/AutoridadesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class AutoridadConfiguration : IEntityTypeConfiguration<Autoridad>
{
    public void Configure(EntityTypeBuilder<Autoridad> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Autoridad> builder)
    {
        builder.ToTable(
            "autoridades",
            tb =>
                tb.HasComment(
                    "Directivos y autoridades que firman certificaciones, vinculadas a periodos lectivos."
                )
        );

        builder.HasKey(e => e.Id).HasName("autoridades_pkey");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Autoridad> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.UnidadId)
            .HasColumnName("unidad_id")
            .IsRequired()
            .HasComment("ID de la unidad académica en la que opera (FK a unidad.id).");

        builder
            .Property(e => e.PeriodoLectivoId)
            .HasColumnName("periodo_lectivo_id")
            .IsRequired()
            .HasComment(
                "ID del periodo lectivo en el que cumple con el cargo (FK a periodo_lectivo.id)."
            );

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Nombre completo de la autoridad.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("nombre")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Nombre completo de la autoridad.");

        builder
            .Property(e => e.Cargo)
            .HasColumnName("cargo")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Cargo que ocupa o tarea que desempeña. Se verá en los certificados.");

        builder
            .Property(e => e.FirmaImg)
            .HasColumnName("firma_img")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Ruta relativa de la imagen o codigo svg de la firma de la autoridad");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activa, false=inactiva).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasComment("Fecha y hora de última actualización del registro.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Autoridad> builder)
    {
        builder
            .HasIndex(e => e.PeriodoLectivoId)
            .HasDatabaseName("IX_autoridades_periodo_lectivo_id");

        builder.HasIndex(e => e.UnidadId).HasDatabaseName("IX_autoridades_unidad_id");

        builder.HasIndex(e => e.Activo).HasDatabaseName("IX_autoridades_estado");

        builder
            .HasIndex(e => new { e.UnidadId, e.PeriodoLectivoId })
            .HasDatabaseName("IX_autoridades_unidad_periodo");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Autoridad> builder)
    {
        builder
            .HasOne(d => d.Unidad)
            .WithMany(p => p.Autoridades)
            .HasForeignKey(d => d.UnidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("autoridades_unidad_id_fkey")
            .IsRequired();

        builder
            .HasOne(d => d.PeriodoLectivo)
            .WithMany(p => p.Autoridades)
            .HasForeignKey(d => d.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("autoridades_periodo_lectivo_id_fkey")
            .IsRequired();
    }
}
