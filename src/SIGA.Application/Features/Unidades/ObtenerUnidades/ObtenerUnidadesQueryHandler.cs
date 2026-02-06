using SIGA.Application.Common.Interfaces;

namespace SIGA.Application.Features.Unidades.ObtenerUnidades;

public class ObtenerUnidadesQueryHandler : IUseCaseHandler<ObtenerUnidadesQuery, Unidades>
{
    public Task<Unidades> Handle(ObtenerUnidadesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
