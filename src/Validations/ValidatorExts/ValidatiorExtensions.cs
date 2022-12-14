using Behlog.Extensions;

namespace Behlog.Core.Validations;

public static partial class ValidatorExtensions
{

    public static ValidatorResult ThrowExceptionIfIdIsNotValid(this ValidatorResult result, Guid id)
    {
        if (id == default)
        {
            throw new BehlogInvalidEntityIdException();
        }

        return result;
    }

    public static ValidatorResult ThrowExceptionIfIdIsNotValid(this ValidatorResult result, Guid? id)
    {
        if (id.HasValue && id.Value == default)
        {
            throw new BehlogInvalidEntityIdException();
        }

        return result;
    }
    
    public static ValidatorResult IsRequired(
        this ValidatorResult result, string? value, string fieldName, 
        string errorMessage, string errorCode = "")
    {
        if (value.IsNullOrEmptySpace())
        {
            return result.WithError(ValidationError
                .Create(fieldName, errorCode, errorMessage)
            );
        }

        return result;
    }


    public static ValidatorResult HasMaxLenght(
        this ValidatorResult result, string? value, int maxLen,
        string fieldName, string errorMessage, string errorCode = "")
    {
        if (!MaxLenValidator.IsValid(value, maxLen))
        {
            return result.WithError(ValidationError
                .Create(fieldName, errorCode, errorMessage)
            );
        }

        return result;
    }


    public static ValidatorResult HasMinLenght(
        this ValidatorResult result, string? value, int minLen,
        string fieldName, string errorMessage, string errorCode = "")
    {
        if (!MinLenValidator.IsValid(value, minLen))
        {
            return result.WithError(ValidationError
                .Create(fieldName, errorCode, errorMessage)
            );
        }

        return result;
    }


    public static ValidatorResult IsEmailFormatCorrect(
        this ValidatorResult result, string email, string fieldName,
        string errorMessage, string errorCode = "")
    {
        if (email.IsNullOrEmptySpace())
            return result;

        if (!EmailValidator.IsValid(email))
        {
            return result.WithError(ValidationError
                .Create(fieldName, errorCode, errorMessage));
        }

        return result;
    }
}