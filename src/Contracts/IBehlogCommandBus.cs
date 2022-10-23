namespace Behlog.Core;

public interface IBehlogCommandBus
{
    Task<TResult> ExecuteAsync<TResult>(
        IBehlogCommand<TResult> command,
        CancellationToken cancellationToken = default);

    Task ExecuteAsync(IBehlogCommand command, CancellationToken cancellationToken = default);
}