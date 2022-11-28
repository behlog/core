namespace Behlog.Core.Validations;

public abstract class ValidationResult1 : IValidationResult
{
    
    protected ValidationResult1(BehlogValidationLevel level)
    {
        Level = level;
    }


    protected ValidationResult1(BehlogValidationLevel level, string message)
    {
        Level = level;
        Message = message;
    }
    
    
    public BehlogValidationLevel Level { get; }
    
    public string Message { get; protected set; }
    
    public string FieldName { get; protected set; }
}