using System.Threading;

namespace Behlog.Core;

public interface IMediator
{
    Task<TResponse> HandleAsync<TResponse>(
        IMessage<TResponse> message,
        CancellationToken cancellationToken = default);

    Task HandleAsync(IMessage message, CancellationToken cancellationToken = default);
}