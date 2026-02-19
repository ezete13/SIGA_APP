namespace SIGA.Application.Common.Dispatcher.Interfaces;

public interface IUseCaseDispatcher
{
    Task<TResponse> Send<TRequest, TResponse>(
        TRequest request,
        CancellationToken cancellationToken = default
    )
        where TRequest : IUseCase<TResponse>;
}
