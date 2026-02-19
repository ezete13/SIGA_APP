namespace SIGA.Application.Common.Dispatcher.Interfaces;

public interface IUseCaseHandler<TRequest, TResponse>
    where TRequest : IUseCase<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
