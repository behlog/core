using Behlog.Core.Validations;

namespace Behlog.Core.Contracts;

public interface IBehlogCommandValidator<in TCommand> where TCommand : IBehlogCommand
{
    
    ValidatorResult Validate(TCommand command);
}


public interface IBehlogCommandValidator<in TCommand, TResult> where TCommand : IBehlogCommand<TResult>
{
    
    ValidatorResult Validate(TCommand command);
}


public interface IBehlogAsyncCommandValidator<in TCommand> where TCommand : IBehlogCommand
{

    Task<ValidatorResult> ValidateAsync(
        TCommand command, CancellationToken cancellationToken = default);
}


public interface IBehlogAsyncCommandValidator<in TCommand, TResult> where TCommand : IBehlogCommand<TResult>
{

    Task<ValidatorResult> ValidateAsync(
        TCommand command, CancellationToken cancellationToken = default);
}

