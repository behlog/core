namespace Behlog.Core.Validations;

public interface IValidationResult
{

    BehlogValidationLevel Level { get; }

    string Message { get; }

    
    string FieldName { get; }
}