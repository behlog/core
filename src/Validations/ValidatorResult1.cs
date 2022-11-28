namespace Behlog.Core.Validations;

public class ValidatorResult1
{
    private ICollection<IValidationResult> _items;
    private ICollection<ValidationError1> _errors;
    private ICollection<ValidationInfo> _infos;
    private ICollection<ValidationWarning> _warnings;

    protected ValidatorResult1()
    {
        _items = new List<IValidationResult>();
        _errors = new List<ValidationError1>();
        _infos = new List<ValidationInfo>();
        _warnings = new List<ValidationWarning>();
    }

    public IReadOnlyCollection<IValidationResult> Validations
        => _items.ToList();


    public IReadOnlyCollection<ValidationError1> Errors
        => _errors.ToList();


    public IReadOnlyCollection<ValidationWarning> Warnings
        => _warnings.ToList();

    
    public IReadOnlyCollection<ValidationInfo> Info
        => _infos.ToList();

    public static ValidatorResult1 Create()
    {
        return new ValidatorResult1();
    }

    public static ValidatorResult1 Failed(ValidationError1 error)
    {
        var result = new ValidatorResult1();
        result.AddError(error);
        return result;
    }

    public static ValidatorResult1 Success()
    {
        return Create();
    }

    public static ValidatorResult1 Success(ValidationInfo info)
    {
        return Create().WithInfo(info);
    }

    public static ValidatorResult1 Success(ValidationWarning warning)
    {
        return Create().WithWarning(warning);
    }

    public static ValidatorResult1 Failed(IEnumerable<ValidationError1> errors)
    {
        var result = Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
    }

    public static ValidatorResult1 Failed(Exception exception)
    {
        var result = Create().WithError(ValidationError1.Create(exception));
        return result;
    } 

    public ValidatorResult1 WithError(ValidationError1 error)
    {
        AddError(error);
        return this;
    }

    public ValidatorResult1 WithInfo(ValidationInfo info)
    {
        AddInfo(info);
        return this;
    }

    public ValidatorResult1 WithWarning(ValidationWarning warning)
    {
        AddWarning(warning);
        return this;
    }

    private void AddError(ValidationError1 error)
    {
        _items.Add(error);
    }

    private void AddWarning(ValidationWarning warning)
    {
        _items.Add(warning);
    }

    private void AddInfo(ValidationInfo info)
    {
        _items.Add(info);
    }
    
    
}