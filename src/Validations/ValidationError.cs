namespace Behlog.Core.Validations;


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
