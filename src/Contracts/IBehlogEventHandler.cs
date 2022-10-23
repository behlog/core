namespace Behlog.Core;

public interface IBehlogEventHandler<in TEvent> : IBehlogMessageHandler<TEvent> where TEvent : IBehlogEvent
{
    
}