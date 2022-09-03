using System.Threading;

namespace Behlog.Core;

public interface IMediator
{
    Task<TResponse> PublishAsync<TResponse>(
        IMessage<TResponse> message,
        CancellationToken cancellationToken = default);

    Task PublishAsync(IMessage message, CancellationToken cancellationToken = default);
}