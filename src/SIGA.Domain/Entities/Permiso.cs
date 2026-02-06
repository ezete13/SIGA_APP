namespace SIGA.Domain.Entities;

public class Permiso
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Modulo { get; set; }

    public required string Accion { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; } = true;

    public int Orden { get; set; }
}
