namespace Behlog.Core;

public class ValidationResult
{
    private ValidationResult() { }

    public ValidationResult(BehlogValidationLevel level)
    {
        Level = level;
    }
    
    public ValidationResult(
        string fieldName, string message,
        BehlogValidationLevel level = BehlogValidationLevel.Error, 
        string errorCode = "")
    {
        FieldName = fieldName;
        Message = message;
        Level = level;
        ErrorCode = errorCode;
    }

    public static ValidationResult Create(
        BehlogValidationLevel level = BehlogValidationLevel.Error)
    {
        return new ValidationResult("", "", level, "");
    }
    
    public ValidationResult WithFiledName(string fieldName)
    {
        FieldName = fieldName;
        return this;
    }

    public ValidationResult WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public ValidationResult WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public ValidationResult Build() => this;

    public string FieldName { get; protected set; }
    public string Message { get; protected set; }
    public BehlogValidationLevel Level { get; protected set; }
    public string ErrorCode { get; protected set; }
    public bool IsError => Level == BehlogValidationLevel.Error;
    public bool IsWarning => Level == BehlogValidationLevel.Warning;
}


public class ValidationError : ValidationResult
{
    public ValidationError() : base(BehlogValidationLevel.Error)
    {
    }

    public ValidationError(
        string fieldName, string errorCode, string message = "")
            : base(fieldName, message, BehlogValidationLevel.Error, errorCode)
    {
    }
}

public class ValidatorResult
{

    public bool HasError => _items.Any(_ => _.IsError);

    public bool IsValid => !HasError;

    public bool HasWarning => _items.Any(_ => _.IsWarning);

    private ValidatorResult()
    {
        _items = new List<ValidationResult>();
    }

    private ICollection<ValidationResult> _items;

    public IReadOnlyCollection<ValidationResult> Items => _items.ToList();


    public void Add(ValidationResult result)
    {
        _items.Add(result);
    }

    public void AddError(ValidationError error)
    {
        _items.Add(error);
    }

    public void AddInfo(string filedName, string message)
    {
        _items.Add(ValidationResult.Create(BehlogValidationLevel.Info)
            .WithFiledName(filedName)
            .WithMessage(message)
            .Build()
        );
    }

    public void AddWarning(string fieldName, string message)
    {
        _items.Add(ValidationResult.Create(BehlogValidationLevel.Warning)
            .WithFiledName(fieldName)
            .WithMessage(message)
            .Build()
        );
    }

    public void AddError(string fieldName, string errorCode, string message)
    {
        _items.Add(ValidationResult.Create()
            .WithFiledName(fieldName)
            .WithErrorCode(errorCode)
            .WithMessage(message)
            .Build()
        );
    }
}