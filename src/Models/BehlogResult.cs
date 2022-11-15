using Behlog.Core.Validations;

namespace Behlog.Core;

public abstract class BehlogResult
{
    
    protected ICollection<ValidationResult> _validations;
    
    protected BehlogResult()
    {
        _validations = new List<ValidationResult>();
    }

    public BehlogResult(ICollection<ValidationResult> validations)
    {
        _validations = validations;
    }

    public IReadOnlyCollection<ValidationResult> Validations => _validations.ToList();

    public bool HasError
        => Validations.Any(_ => _.Level == BehlogValidationLevel.Error);

    public bool HasWarning
        => Validations.Any(_ => _.Level == BehlogValidationLevel.Warning);

    public bool IsSuccess => !HasError;
    
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

    public BehlogResult AddValidationError(ValidationError error)
    {
        _validations.Add(error);
        return this;
    }

    public BehlogResult AddValidationError(string message)
    {
        _validations.Add(ValidationResult.Create()
            .WithMessage(message)
            .Build());
        return this;
    }

    public BehlogResult WithValidationErrors(IEnumerable<ValidationError> errors)
    {
        foreach (var error in errors)
        {
            _validations.Add(error);
        }

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


    // public T WithValidatorResult<T>(ValidatorResult result) where T : BehlogResult
    // {
    //     if (result.HasError)
    //     {
    //         foreach (var validationResult in result.Items)
    //         {
    //             _validations.Add(validationResult);
    //         }
    //     }
    //
    //     return (T)this;
    // } 
}