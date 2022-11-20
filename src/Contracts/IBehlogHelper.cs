namespace Behlog.Core.Contracts;

public interface IBehlogHelper
{
    
    Task PublishAsync<TAggregate, TId>(
        TAggregate aggregate, CancellationToken cancellationToken = default)
        where TAggregate : IAggregateRoot<TId>;

    void LogInfo(string what);

    void LogError(string error);

    void LogException(Exception exception);
}