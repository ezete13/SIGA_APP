using SIGA.Application.Common;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Catalog.Dynamic;
using SIGA.Persistence;

namespace SIGA.Application.Features.Unidades.CrearUnidad;

public class CrearUnidadCommandHandler : IUseCaseHandler<CrearUnidadCommand, AppResult<Unidad>>
{
    private readonly ApplicationDbContext _dbContext;

    public CrearUnidadCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResult<Unidad>> Handle(
        CrearUnidadCommand request,
        CancellationToken cancellationToken
    )
    {
        var unidad = new Unidad
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            NombreCorto = request.NombreCorto,
            Siglas = request.Siglas,
            ColorPrincipal = request.ColorPrincipal,
            ColorSecundario = request.ColorSecundario,
            Direccion = request.Direccion,
            Telefono = request.Telefono,
            Email = request.Email,
        };

        _dbContext.Add(unidad);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return AppResult<Unidad>.Success(unidad);
    }
}
