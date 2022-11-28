namespace Behlog.Core.Validations;


public class ValidationInfo : ValidationResult1, IValidationResult
{

    private ValidationInfo() : base(BehlogValidationLevel.Info)
    {
    }

    
    public static ValidationInfo Create(string message)
    {
        var info = new ValidationInfo
        {
            Message = message
        };
        return info;
    }

    public ValidationInfo WithFieldName(string fieldName)
    {
        this.FieldName = fieldName;
        return this;
    }
}