namespace Behlog.Core;

public class BehlogResult
{
    
    private ICollection<ValidationResult> _validations;
    
    protected BehlogResult()
    {
        _validations = new List<ValidationResult>();
    }

    public IReadOnlyCollection<ValidationResult> Validations => _validations.ToList();

    public bool HasError
        => Validations.Any(_ => _.Level == BehlogValidationLevel.Error);

    public bool HasWarning
        => Validations.Any(_ => _.Level == BehlogValidationLevel.Warning);

    public bool IsSuccess => !HasError;

    public static BehlogResult Create()
    {
        return new BehlogResult();
    }

    public BehlogResult AddValidationError(string fieldName, string message)
    {
        _validations.Add(ValidationResult.Create()
            .WithFiledName(fieldName)
            .WithMessage(message)
            .Build());
        return this;
    }

    public BehlogResult AddValidationError(string fieldName, string message, string errorCode)
    {
        _validations.Add(ValidationResult.Create()
            .WithFiledName(fieldName)
            .WithMessage(message)
            .WithErrorCode(errorCode)
            .Build());
        return this;
    }

    public BehlogResult AddValidationError(string message)
    {
        _validations.Add(ValidationResult.Create()
            .WithMessage(message)
            .Build());
        return this;
    }

    public BehlogResult AddWarning(string fieldName, string message)
    {
        _validations.Add(ValidationResult.Create(BehlogValidationLevel.Warning)
            .WithFiledName(fieldName)
            .WithMessage(message)
            .Build());
        return this;
    }

    public BehlogResult AddInfo(string fieldName, string message)
    {
        _validations.Add(ValidationResult.Create(BehlogValidationLevel.Info)
            .WithFiledName(fieldName)
            .WithMessage(message)
            .Build());
        return this;
    }
}