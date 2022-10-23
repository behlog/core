namespace Behlog.Core;

public abstract class BehlogQueryHandler<TQuery, TResponse> : IBehlogQueryHandler<TQuery, TResponse> 
    where TQuery : IBehlogQuery<TResponse>
{
    public Task<TResponse> HandleAsync(TQuery message,
        CancellationToken cancellationToken)
    {
        return HandleQueryAsync(message, cancellationToken);
    }

    protected abstract Task<TResponse> HandleQueryAsync(TQuery query, 
        CancellationToken cancellationToken);
}
