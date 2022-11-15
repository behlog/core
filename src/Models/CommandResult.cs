using Behlog.Core.Validations;
using Behlog.Extensions;

namespace Behlog.Core.Models;

public class CommandResult
{

    private ICollection<ValidationResult> _validations;

    protected CommandResult()
    {
        _validations = new List<ValidationResult>();
    }

    public IReadOnlyCollection<ValidationResult> Validations => _validations.ToList();

    public bool HasError => _validations.Any(_ => _.IsError);

    public bool Succeed => !HasError;

    public bool HasWarning => _validations.Any(_=> _.IsWarning);


    public static CommandResult Create()
    {
        return new CommandResult();
    }


    public CommandResult WithErrors(IReadOnlyCollection<ValidationError> errors)
    {
        foreach (var error in errors)
        {
            AddError(error);
        }
        
        return this;
    }

    public CommandResult AddError(ValidationError error)
    {
        error.ThrowExceptionIfArgumentIsNull(nameof(error));
        _validations.Add(error);
        
        return this;
    }


    public CommandResult AddValidation(ValidationResult validation)
    {
        validation.ThrowExceptionIfArgumentIsNull(nameof(validation));
        _validations.Add(validation);

        return this;
    }
    
    public CommandResult WithValidations(IReadOnlyCollection<ValidationResult> validations)
    {
        foreach(var item in validations)
        {
            AddValidation(item);
        }

        return this;
    }
    
    
    public static CommandResult FromValidator(ValidatorResult validatorResult)
    {
        validatorResult.ThrowExceptionIfArgumentIsNull(nameof(validatorResult));

        var commandResult = CommandResult.Create();

        if (validatorResult.IsValid)
            return commandResult;

        foreach (var item in validatorResult.Items)
        {
            commandResult._validations.Add(item);
        }

        return commandResult;
    }
}


public class CommandResult<TResult> : CommandResult where TResult : class
{

    public CommandResult(TResult result)
    {
        Result = result;
    }
    
    public TResult Result { get; }
}