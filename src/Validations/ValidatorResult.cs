namespace Behlog.Core.Validations;

public class ValidatorResult
{
    private ICollection<IValidationResult> _items;
    private ICollection<ValidationError> _errors;
    private ICollection<ValidationInfo> _infos;
    private ICollection<ValidationWarning> _warnings;

    protected ValidatorResult()
    {
        _items = new List<IValidationResult>();
        _errors = new List<ValidationError>();
        _infos = new List<ValidationInfo>();
        _warnings = new List<ValidationWarning>();
    }

    public IReadOnlyCollection<IValidationResult> Validations
        => _items.ToList();


    public IReadOnlyCollection<ValidationError> Errors
        => _errors.ToList();


    public IReadOnlyCollection<ValidationWarning> Warnings
        => _warnings.ToList();

    
    public IReadOnlyCollection<ValidationInfo> Info
        => _infos.ToList();

    public static ValidatorResult Create()
    {
        return new ValidatorResult();
    }

    public static ValidatorResult Failed(ValidationError error)
    {
        var result = new ValidatorResult();
        result.AddError(error);
        return result;
    }

    public static ValidatorResult Success()
    {
        return Create();
    }

    public static ValidatorResult Success(ValidationInfo info)
    {
        return Create().WithInfo(info);
    }

    public static ValidatorResult Success(ValidationWarning warning)
    {
        return Create().WithWarning(warning);
    }

    public static ValidatorResult Failed(IEnumerable<ValidationError> errors)
    {
        var result = Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
    }

    public static ValidatorResult Failed(Exception exception)
    {
        var result = Create().WithError(ValidationError.Create(exception));
        return result;
    } 

    public ValidatorResult WithError(ValidationError error)
    {
        AddError(error);
        return this;
    }

    public ValidatorResult WithInfo(ValidationInfo info)
    {
        AddInfo(info);
        return this;
    }

    public ValidatorResult WithWarning(ValidationWarning warning)
    {
        AddWarning(warning);
        return this;
    }

    private void AddError(ValidationError error)
    {
        _errors.Add(error);
        _items.Add(error);
    }

    private void AddWarning(ValidationWarning warning)
    {
        _warnings.Add(warning);
        _items.Add(warning);
    }

    private void AddInfo(ValidationInfo info)
    {
        _infos.Add(info);
        _items.Add(info);
    }
    
    
}