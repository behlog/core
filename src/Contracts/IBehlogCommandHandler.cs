namespace Behlog.Core;

public interface IBehlogCommandHandler<in TCommand, TResult> : IBehlogMessageHandler<TCommand, TResult> 
    where TCommand : IBehlogCommand<TResult> 
{
}

public interface IBehlogCommandHandler<in TCommand> : IBehlogMessageHandler<TCommand>
    where TCommand : IBehlogCommand
{
}