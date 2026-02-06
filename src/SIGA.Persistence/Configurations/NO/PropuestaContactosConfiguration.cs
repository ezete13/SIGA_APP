// SIGA.Persistence/Configurations/PropuestaContactosConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestaContactosConfiguration : IEntityTypeConfiguration<PropuestaContactos>
{
    public void Configure(EntityTypeBuilder<PropuestaContactos> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuesta_contactos_pkey");

        builder.ToTable(
            "propuesta_contactos",
            tb => tb.HasComment("Información de contacto específica para cada propuesta académica.")
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
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Nombre de la persona o área de contacto.");

        builder
            .Property(e => e.Tipo)
            .HasColumnName("tipo")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasComment("Tipo de contacto: administrativo, académico, pagos, general.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Correo electrónico de contacto.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasComment("Teléfono de contacto.");

        builder
            .Property(e => e.HorarioAtencion)
            .HasColumnName("horario_atencion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Horario de atención al público.");

        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden de aparición en la web para mostrar múltiples contactos.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de creación del registro.");

        // RELACIONES
        builder
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.PropuestaContactos)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("propuesta_contactos_propuesta_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => e.PropuestaId)
            .HasDatabaseName("IX_propuesta_contactos_propuesta_id");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_propuesta_contactos_estado");

        builder.HasIndex(e => e.Orden).HasDatabaseName("IX_propuesta_contactos_orden");

        builder.HasIndex(e => e.Tipo).HasDatabaseName("IX_propuesta_contactos_tipo");
    }
}
