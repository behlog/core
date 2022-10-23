using System.Reflection;

namespace Behlog.Core;

public class BehlogManager : IBehlogManager
{
    private readonly IBehlogServiceFactory _serviceFactory;

    public BehlogManager(IBehlogServiceFactory serviceFactory)
    {
        _serviceFactory = serviceFactory;
    }
    
    public Task<TResponse> PublishAsync<TResponse>(
        IBehlogMessage<TResponse> message, 
        CancellationToken cancellationToken = default)
    {
        var targetType = message.GetType(); 
        var targetHandler = typeof(IBehlogMessageProcessor<,>).MakeGenericType(targetType, typeof(TResponse));
        var instance = _serviceFactory.GetInstance(targetHandler);
  
        var result = InvokeInstanceAsync(instance, message, targetHandler, cancellationToken);

        return result;
    }

    public async Task PublishAsync(IBehlogMessage message, CancellationToken cancellationToken = default)
    {
        var targetType = message.GetType();
        var targetHandler = typeof(IBehlogMessageProcessor<>).MakeGenericType(targetType);
        var instance = _serviceFactory.GetInstance(targetHandler);

        var result = InvokeInstanceAsync(instance, message, targetHandler, cancellationToken);
    }
    
    private Task<TResponse> InvokeInstanceAsync<TResponse>(
        object instance, 
        IBehlogMessage<TResponse> message, 
        Type targetHandler, 
        CancellationToken cancellationToken)
    {
        var method = instance.GetType()
            .GetTypeInfo()
            .GetMethod(nameof(IBehlogMessageProcessor<IBehlogMessage<TResponse>, TResponse>.HandleAsync));

        if (method == null)
        {
            throw new ArgumentException(
                $"{instance.GetType().Name} is not a known {targetHandler.Name}",
                instance.GetType().FullName);
        }

        return (Task<TResponse>)method.Invoke(instance, new object[]
        {
            message, cancellationToken
        })!;
    }

    private Task InvokeInstanceAsync(
        object instance, 
        IBehlogMessage message, 
        Type targetHandler,
        CancellationToken cancellationToken)
    {
        var method = instance.GetType()
            .GetTypeInfo()
            .GetMethod(nameof(IBehlogMessageProcessor<IBehlogMessage>.HandleAsync));

        if (method == null)
        {
            throw new ArgumentException(
                $"{instance.GetType().Name} is not a known {targetHandler.Name}",
                instance.GetType().FullName);
        }

        return (Task)method.Invoke(instance, new object[]
        {
            message, cancellationToken 
            
        })!;
    }
}