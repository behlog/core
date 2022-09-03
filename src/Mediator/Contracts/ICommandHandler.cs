namespace Behlog.Core;

public interface ICommandHandler<in TCommand, TResult> : IMessageHandler<TCommand, TResult> 
    where TCommand : IMessage<TResult> 
{
    
}