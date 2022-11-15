using System.Linq.Expressions;

namespace Behlog.Core.Validations;

public class CommandValidatorResult<TCommand> : ValidatorResult where TCommand : IBehlogCommand
{
    
}