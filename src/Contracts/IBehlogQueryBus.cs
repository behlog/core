namespace Behlog.Core;

public interface IBehlogQueryBus
{
 
    Task<TResponse> ExecuteAsync<TResponse>(
        IBehlogQuery<TResponse> query,
        CancellationToken cancellationToken = default);
}