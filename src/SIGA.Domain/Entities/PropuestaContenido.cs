namespace SIGA.Domain.Entities;

public class PropuestaContenido
{
    public int Id { get; set; }

    public required int PropuestaId { get; set; }

    public required string TituloModulo { get; set; }

    public required string? Descripcion { get; set; }

    public required int Orden { get; set; }

    public int? Horas { get; set; }

    public virtual required Propuesta Propuesta { get; set; }
}
