using Behlog.Core.Validations;
using Behlog.Extensions;

namespace Behlog.Core.Models;

public class CommandResult
{

    protected ICollection<ValidationResult> _validations;

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
    
    public static CommandResult FailedWith(ValidationError error)
    {
        error.ThrowExceptionIfArgumentIsNull(nameof(error));
        var commandResult = new CommandResult();
        commandResult.AddError(error);

        return commandResult;
    }


    public static CommandResult FailedWith(IReadOnlyCollection<ValidationError> errors)
    {
        if (errors is null || !errors.Any())
            throw new ArgumentNullException(nameof(errors));

        var result = Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
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

