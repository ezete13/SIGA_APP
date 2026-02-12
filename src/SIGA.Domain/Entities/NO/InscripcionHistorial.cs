namespace SIGA.Domain.Entities;

public partial class InscripcionHistorial
{
    public int InscripcionId { get; set; }

    public int TipoEstadoInscripcionId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? CreadoEn { get; set; }

    public virtual required Inscripcion Inscripcion { get; set; }

    public virtual required EstadoInscripcion EstadoInscripcion { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
