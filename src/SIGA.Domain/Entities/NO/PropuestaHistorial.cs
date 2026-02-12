namespace SIGA.Domain.Entities;

public partial class PropuestaHistorial
{
    public int Id { get; set; }

    public int PropuestaId { get; set; }

    public int EstadoPropuestaId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? CreadoEn { get; set; }

    public virtual required Propuesta Propuesta { get; set; }

    public virtual required EstadoPropuesta EstadoPropuesta { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
