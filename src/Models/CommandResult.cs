using Behlog.Core.Validations;

namespace Behlog.Core.Models;

public class CommandResult
{
    protected ICollection<IValidationResult> _validations;

    protected CommandResult()
    {
        _validations = new List<IValidationResult>();
        _errors = new List<ValidationError>();
        _warnings = new List<ValidationWarning>();
        _infos = new List<ValidationInfo>();
    }

    protected ICollection<ValidationError> _errors;
    protected ICollection<ValidationWarning> _warnings;
    protected ICollection<ValidationInfo> _infos;


    public bool HasError => _errors.Any();

    public bool IsValid => !HasError;

    public bool HasWarning => _warnings.Any();


    public static CommandResult Create()
    {
        return new CommandResult();
    }

    public static CommandResult Failed(ValidationError error)
    {
        var result = Create();
        result.AddError(error);
        return result;
    }

    public static CommandResult Failed(IEnumerable<ValidationError> errors)
    {
        var result = Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
    }


    public static CommandResult Success()
    {
        return Create();
    }

    public static CommandResult Success(ValidationWarning warning)
    {
        var result = Create();
        result.AddWarning(warning);
        return result;
    }

    public static CommandResult Success(IEnumerable<ValidationWarning> warnings)
    {
        var result = Create();
        foreach (var w in warnings)
        {
            result.AddWarning(w);
        }

        return result;
    }

    public static CommandResult Success(ValidationInfo info)
    {
        var result = Create();
        result.AddInfo(info);
        return result;
    }

    protected void AddError(ValidationError error)
    {
        _validations.Add(error);
        _errors.Add(error);
    }

    protected void AddWarning(ValidationWarning warning)
    {
        _validations.Add(warning);
        _warnings.Add(warning);
    }

    protected void AddInfo(ValidationInfo info)
    {
        _validations.Add(info);
        _infos.Add(info);
    }
    
    
}