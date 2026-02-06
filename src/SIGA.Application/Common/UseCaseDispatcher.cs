using Microsoft.Extensions.DependencyInjection;
using SIGA.Application.Common.Interfaces;

namespace SIGA.Application.Common;

public class UseCaseDispatcher : IUseCaseDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public UseCaseDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TRequest, TResponse>(
        TRequest request,
        CancellationToken cancellationToken = default
    )
        where TRequest : IUseCase<TResponse>
    {
        var handler = _serviceProvider.GetRequiredService<IUseCaseHandler<TRequest, TResponse>>();

        return await handler.Handle(request, cancellationToken);
    }
}
