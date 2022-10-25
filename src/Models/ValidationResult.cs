namespace Behlog.Core;

public class ValidationResult
{
    private ValidationResult() { }

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
}