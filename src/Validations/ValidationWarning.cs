namespace Behlog.Core.Validations;

public class ValidationWarning : ValidationResult1, IValidationResult
{
    
    protected ValidationWarning() : base(BehlogValidationLevel.Warning)
    {
    }


    public static ValidationWarning Create(string message)
    {
        var warning = new ValidationWarning
        {
            Message = message
        };
        return warning;
    }

    public ValidationWarning WithFieldName(string fieldName)
    {
        this.FieldName = fieldName;
        return this;
    }
    
}