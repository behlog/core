using Behlog.Core;

namespace Behlog.Core.Contracts;

public interface IBehlogCommandValidator<in TCommand> where TCommand : IBehlogCommand
{
    
    ValidatorResult Validate(TCommand command);
}


public interface IBehlogAsyncCommandValidator<in TCommand> where TCommand : IBehlogCommand
{

    Task<ValidatorResult> ValidateAsync(
        TCommand command, CancellationToken cancellationToken = default);
}


