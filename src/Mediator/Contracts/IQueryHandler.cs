namespace Behlog.Core;

public interface IQueryHandler<in TQuery, TResponse> : IMessageHandler<TQuery, TResponse>
    where TQuery : IMessage<TResponse>
{
    
}