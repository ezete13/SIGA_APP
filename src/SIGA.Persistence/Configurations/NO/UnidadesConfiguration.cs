// SIGA.Persistence/Configurations/UnidadesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class UnidadesConfiguration : IEntityTypeConfiguration<Unidades>
{
    public void Configure(EntityTypeBuilder<Unidades> builder)
    {
        builder.HasKey(e => e.Id).HasName("unidades_pkey");

        builder.ToTable(
            "unidades",
            tb => tb.HasComment("Unidades académicas que operan dentro de una sede (Facultades).")
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Código interno único.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment(
                "Nombre o título de reconocimiento formal. Ej: Facultad de Ciencias Económicas."
            );

        builder
            .Property(e => e.NombreCorto)
            .HasColumnName("nombre_corto")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre abreviado para usos internos. Ej: Económicas.");

        builder
            .Property(e => e.Siglas)
            .HasColumnName("siglas")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Sigla institucional única. Ej: FCE, FCM.");

        builder
            .Property(e => e.SedeId)
            .HasColumnName("sede_id")
            .IsRequired()
            .HasComment("ID de la sede a la que pertenece (FK a sede.id).");

        builder
            .Property(e => e.Direccion)
            .HasColumnName("direccion")
            .IsRequired(false)
            .HasComment("Dirección física.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasComment("Teléfono de contacto.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Email institucional.");

        builder
            .Property(e => e.ColorPrincipal)
            .HasColumnName("color_principal")
            .HasMaxLength(7)
            .HasDefaultValue("#064a31")
            .IsRequired()
            .HasComment("Color primario de identidad visual en formato HEX. Ej: #064a31.");

        builder
            .Property(e => e.ColorSecundario)
            .HasColumnName("color_secundario")
            .HasMaxLength(7)
            .HasDefaultValue("#7d1b1c")
            .IsRequired()
            .HasComment(
                "Color secundario para gradientes o elementos de diseño en formato HEX. Ej: #7d1b1c."
            );

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activa, false=inactiva).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de última actualización del registro.");

        // RELACIONES
        builder
            .HasOne(d => d.Sede)
            .WithMany(p => p.Unidades)
            .HasForeignKey(d => d.SedeId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("unidades_sede_id_fkey")
            .IsRequired();

        // RELACIONES INVERSAS
        builder
            .HasMany(u => u.Propuestas)
            .WithOne(p => p.Unidad)
            .HasForeignKey(p => p.UnidadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(u => u.Autoridades)
            .WithOne(a => a.Unidad)
            .HasForeignKey(a => a.UnidadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(u => u.UsuarioPermisosUnidad)
            .WithOne(upu => upu.Unidad)
            .HasForeignKey(upu => upu.UnidadId)
            .OnDelete(DeleteBehavior.Cascade);

        // ÍNDICES
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("unidades_codigo_key");

        builder.HasIndex(e => e.Siglas).IsUnique().HasDatabaseName("unidades_siglas_key");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_unidades_nombre");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_unidades_estado");

        builder.HasIndex(e => e.SedeId).HasDatabaseName("IX_unidades_sede_id");

        // Propiedad computada para nombre completo
        builder
            .Property(e => e.NombreCompleto)
            .HasComputedColumnSql("nombre || ' (' || siglas || ')'", stored: true)
            .HasColumnName("nombre_completo")
            .HasComment("Nombre completo con siglas (computado).");
    }
}
