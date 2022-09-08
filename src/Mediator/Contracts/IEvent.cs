namespace Behlog.Core;

public interface IEvent : IMessage
{
    
}

public interface IEvent<TResult> : IMessage<TResult>
{
    
}