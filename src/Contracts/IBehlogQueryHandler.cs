namespace Behlog.Core;

public interface IBehlogQueryHandler<in TQuery, TResponse> : IBehlogMessageHandler<TQuery, TResponse>
    where TQuery : IBehlogMessage<TResponse>
{
    
}