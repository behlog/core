using Behlog.Core.Validations;

namespace Behlog.Core.Models;

public class CommandResult1
{
    protected ICollection<IValidationResult> _validations;

    protected CommandResult1()
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

    public bool HasWarning => _warnings.Any();


    public static CommandResult1 Create()
    {
        return new CommandResult1();
    }

    public static CommandResult1 Failed(ValidationError error)
    {
        var result = Create();
        result.AddError(error);
        return result;
    }

    public static CommandResult1 Failed(IEnumerable<ValidationError> errors)
    {
        var result = Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
    }


    public static CommandResult1 Success()
    {
        return Create();
    }

    public static CommandResult1 Success(ValidationWarning warning)
    {
        var result = Create();
        result.AddWarning(warning);
        return result;
    }

    public static CommandResult1 Success(IEnumerable<ValidationWarning> warnings)
    {
        var result = Create();
        foreach (var w in warnings)
        {
            result.AddWarning(w);
        }

        return result;
    }

    public static CommandResult1 Success(ValidationInfo info)
    {
        var result = Create();
        result.AddInfo(info);
        return result;
    }

    private void AddError(ValidationError error)
    {
        _validations.Add(error);
        _errors.Add(error);
    }

    private void AddWarning(ValidationWarning warning)
    {
        _validations.Add(warning);
        _warnings.Add(warning);
    }

    private void AddInfo(ValidationInfo info)
    {
        _validations.Add(info);
        _infos.Add(info);
    }
    
    
}