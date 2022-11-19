using Behlog.Core.Validations;
using Behlog.Extensions;

namespace Behlog.Core.Models;

public class CommandResult<TResult> : CommandResult where TResult : class
{

    protected CommandResult() : base()
    {
    }

    private CommandResult(TResult result)
    {
        Result = result ?? throw new ArgumentNullException(nameof(result));
    }

    public TResult Result { get; protected set; }
    
    
    public new static CommandResult<TResult> Create()
    {
        return new CommandResult<TResult>();
    }

    public new CommandResult<TResult> With(TResult result)
    {
        Result = result;
        return this;
    }


    public new CommandResult<TResult> AddValidation(ValidationResult validation)
    {
        validation.ThrowExceptionIfArgumentIsNull(nameof(validation));
        _validations.Add(validation);
        
        return this;
    }


    public new CommandResult<TResult> AddError(ValidationError error)
    {
        error.ThrowExceptionIfArgumentIsNull(nameof(error));
        _validations.Add(error);

        return this;
    }


    public new CommandResult<TResult> WithValidations(IReadOnlyCollection<ValidationResult> validations)
    {
        validations.ThrowExceptionIfArgumentIsNull(nameof(validations));
        foreach (var v in validations)
        {
            AddValidation(v);
        }
        
        return this;
    }


    public new static CommandResult<TResult> FailedWith(ValidationError error)
    {
        var result = new CommandResult<TResult>();
        result.AddError(error);

        return result;
    }

    public new static CommandResult<TResult> FailedWith(IReadOnlyCollection<ValidationError> errors)
    {
        if (errors is null || !errors.Any())
            throw new ArgumentNullException(nameof(errors));
        
        var result = CommandResult<TResult>.Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
    }



    public new static CommandResult<TResult> FromValidator(ValidatorResult validatorResult)
    {
        validatorResult.ThrowExceptionIfArgumentIsNull(nameof(validatorResult));

        var commandResult = Create();
        if (validatorResult.IsValid)
            return commandResult;

        foreach (var item in validatorResult.Items)
        {
            commandResult._validations.Add(item);
        }

        return commandResult;
    }

}