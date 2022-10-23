using System.Reflection;
using iman.Domain;

namespace Behlog.Core;

public class BehlogQueryBus : IBehlogQueryBus
{
    private readonly IBehlogServiceFactory _serviceFactory;

    public BehlogQueryBus(IBehlogServiceFactory serviceFactory)
    {
        _serviceFactory = serviceFactory;
    }

    public async Task<TResponse> ExecuteAsync<TResponse>(
        IBehlogQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var handler = typeof(IBehlogMessageProcessor<,>).MakeGenericType(
            query.GetType(), typeof(TResponse));
        var instance = _serviceFactory.GetInstance(handler);
        var method = instance.GetType().GetTypeInfo()
            .GetMethod(nameof(IBehlogMessageProcessor<IBehlogCommand<TResponse>, TResponse>.HandleAsync));

        if (method == null)
        {
            throw new InvalidQueryHandlerInstanceException(handler.Name);
        }

        return await (Task<TResponse>)method.Invoke(instance, new object[]
        {
            query, cancellationToken
        })!;
    }
}