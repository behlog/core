using Behlog.Extensions;

namespace Behlog.Core.Validations;

public static partial class ValidatorExtensions
{


    public static ValidatorResult1 IsRequired(
        this ValidatorResult1 result, string? value, string fieldName, 
        string errorMessage, string errorCode = "")
    {
        if (value.IsNullOrEmptySpace())
        {
            return result.WithError(ValidationError1
                .Create(fieldName, errorCode, errorMessage)
            );
        }

        return result;
    }


    public static ValidatorResult1 HasMaxLenght(
        this ValidatorResult1 result, string? value, int maxLen,
        string fieldName, string errorMessage, string errorCode = "")
    {
        if (!MaxLenValidator.IsValid(value, maxLen))
        {
            return result.WithError(ValidationError1
                .Create(fieldName, errorCode, errorMessage)
            );
        }

        return result;
    }


    public static ValidatorResult1 HasMinLenght(
        this ValidatorResult1 result, string? value, int minLen,
        string fieldName, string errorMessage, string errorCode = "")
    {
        if (!MinLenValidator.IsValid(value, minLen))
        {
            return result.WithError(ValidationError1
                .Create(fieldName, errorCode, errorMessage)
            );
        }

        return result;
    }


    public static ValidatorResult1 IsEmailFormatCorrect(
        this ValidatorResult1 result, string email, string fieldName,
        string errorMessage, string errorCode = "")
    {
        if (email.IsNullOrEmptySpace())
            return result;

        if (!EmailValidator.IsValid(email))
        {
            return result.WithError(ValidationError1
                .Create(fieldName, errorMessage, errorCode));
        }

        return result;
    }
}