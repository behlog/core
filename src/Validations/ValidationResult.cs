namespace Behlog.Core.Validations;

public abstract class ValidationResult : IValidationResult
{
    
    protected ValidationResult(BehlogValidationLevel level)
    {
        Level = level;
    }


    protected ValidationResult(BehlogValidationLevel level, string message)
    {
        Level = level;
        Message = message;
    }
    
    
    public BehlogValidationLevel Level { get; }
    
    public string Message { get; protected set; }
    
    public string FieldName { get; protected set; }
}