namespace Behlog.Core;

public interface IEventHandler<in TEvent> : IMessageHandler<TEvent> where TEvent : IMessage
{
    
}