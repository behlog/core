namespace Behlog.Core;

public interface ICommand : IMessage
{
    
}

public interface ICommand<TResult> : IMessage<TResult>
{
    
}