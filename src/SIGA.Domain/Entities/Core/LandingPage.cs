namespace SIGA.Domain.Entities.Core;

public partial class PropuestaWeb
{
    public int Id { get; set; }

    public int PropuestaId { get; set; }

    public string? TituloWeb { get; set; }

    public string Slug { get; set; } = null!;

    public string? BannerImg { get; set; }

    public string? AcercaDe { get; set; }

    public string? PerfilEstudiante { get; set; }

    public string? Requisitos { get; set; }

    public string? Destinatarios { get; set; }

    public string? Fundamentacion { get; set; }

    public string? Etiquetas { get; set; }

    public bool? PermiteInscripciones { get; set; }

    public string? MetaOgTitle { get; set; }

    public string? MetaOgImage { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public int? Visitas { get; set; }

    public bool? Estado { get; set; }

    public DateTime? CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }

    public virtual Propuesta Propuesta { get; set; } = null!;
}
