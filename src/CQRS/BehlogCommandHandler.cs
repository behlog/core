namespace Behlog.Core;

public abstract class BehlogCommandHandler<TCommand, TResult> : IBehlogCommandHandler<TCommand, TResult> 
    where TCommand : IBehlogCommand<TResult> where TResult : new()
{
    public async Task<TResult> HandleAsync(TCommand message,
        CancellationToken cancellationToken)
    {
        await HandleCommandAsync(message, cancellationToken);
        return new TResult();
    }

    protected abstract Task HandleCommandAsync(
        TCommand command,
        CancellationToken cancellationToken);
}

public abstract class CommandHandler<TCommand> : IBehlogCommandHandler<TCommand>
    where TCommand : IBehlogCommand
{
    public async Task HandleAsync(TCommand message, CancellationToken cancellationToken)
    {
        await HandleCommandAsync(message, cancellationToken);
    }
    
    protected abstract Task HandleCommandAsync(
        TCommand command,
        CancellationToken cancellationToken);
}