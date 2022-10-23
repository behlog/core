namespace Behlog.Core;

public interface IBehlogEvent : IBehlogMessage
{
    
}

public interface IBehlogEvent<TResult> : IBehlogMessage<TResult>
{
    
}