using System.Reflection;

namespace Behlog.Core;

public class BehlogCommandBus : IBehlogCommandBus
{
    private readonly IBehlogServiceFactory _serviceFactory;

    public BehlogCommandBus(IBehlogServiceFactory serviceFactory)
    {
        _serviceFactory = serviceFactory;
    }

    public async Task<TResult> ExecuteAsync<TResult>(
        IBehlogCommand<TResult> command, CancellationToken cancellationToken = default)
    {
        var handler = typeof(IBehlogMessageProcessor<,>).MakeGenericType(
            command.GetType(), typeof(TResult));
        var instance = _serviceFactory.GetInstance(handler);
        var method = instance.GetType().GetTypeInfo()
            .GetMethod(nameof(IBehlogMessageProcessor<IBehlogCommand<TResult>, TResult>.HandleAsync));
        
        if (method == null)
        {
            throw new BehlogInvalidHandlerInstanceException(handler.Name);
        }

        return await (Task<TResult>)method.Invoke(instance, new object[]
        {
            command, cancellationToken
        })!;
    }

    public async Task ExecuteAsync(
        IBehlogCommand command, CancellationToken cancellationToken = default)
    {
        var handler =  typeof(IBehlogMessageProcessor<>).MakeGenericType(
            command.GetType());
        var instance = _serviceFactory.GetInstance(handler);
        var method = instance.GetType().GetTypeInfo()
            .GetMethod(nameof(IBehlogMessageProcessor<IBehlogCommand>.HandleAsync));
        if (method == null)
        {
            throw new BehlogInvalidHandlerInstanceException(handler.Name);
        }

        await (Task)method.Invoke(instance, new object[]
        {
            command, cancellationToken
        })!;
    }
}