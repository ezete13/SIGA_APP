using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Catalog.Dynamic;
using SIGA.Persistence;

namespace SIGA.Application.Features.Modalidades.CrearModalidad;

public class CrearModalidadCommandHandler : IUseCaseHandler<CrearModalidadCommand, Modalidad>
{
    private readonly ApplicationDbContext _dbContext;

    public CrearModalidadCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Modalidad> Handle(
        CrearModalidadCommand request,
        CancellationToken cancellationToken
    )
    {
        var modalidad = new Modalidad
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
        };

        _dbContext.Add(modalidad);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return modalidad;
    }
}
